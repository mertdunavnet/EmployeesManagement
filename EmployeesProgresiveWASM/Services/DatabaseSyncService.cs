using Microsoft.Extensions.Hosting;
using Microsoft.JSInterop;

namespace EmployeesProgresiveWASM.Services
{
    public class DatabaseSyncService : IHostedService, IDisposable
    {
        private readonly ILogger<DatabaseSyncService> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IndexedDbService _indexedDbService;
        private readonly IJSRuntime _jsRuntime;
        private Timer _timer;

        public DatabaseSyncService(ILogger<DatabaseSyncService> logger, IEmployeeService employeeService, IndexedDbService indexedDbService, IJSRuntime jsRuntime)
        {
            _logger = logger;
            _employeeService = employeeService;
            _indexedDbService = indexedDbService;
            _jsRuntime = jsRuntime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Database Sync Service is starting.");
            /*PerformSync(null);*/ // İlk senkronizasyon işlemi
            _timer = new Timer(PerformSync, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private async void PerformSync(object state)
        {
            try
            {
                _logger.LogInformation("Performing sync...");
                var isOnline = await _jsRuntime.InvokeAsync<bool>("checkOnlineStatus");
                if (!isOnline)
                {
                    _logger.LogInformation("Device is offline. Sync operations skipped.");
                    return;
                }

                _logger.LogInformation("Device is online. Starting sync operations.");
                await SyncFromServerToLocal();
                await SyncFromLocalToServer();
                _logger.LogInformation("Sync operations completed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during sync operations.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Database Sync Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public async Task SyncFromServerToLocal()
        {
            _logger.LogInformation("Syncing from server to local database.");
            try
            {
                var serverEmployees = await _employeeService.GetEmployeesAsync();
                var localEmployees = await _indexedDbService.GetEmployeesAsync();

                var serverEmployeeIds = serverEmployees.Select(e => e.Id).ToHashSet();

                foreach (var serverEmployee in serverEmployees)
                {
                    var localEmployee = localEmployees.FirstOrDefault(e => e.Id == serverEmployee.Id);
                    if (localEmployee == null)
                    {
                        await _indexedDbService.AddEmployeeAsync(serverEmployee);
                        _logger.LogInformation($"Added employee {serverEmployee.Id} to IndexedDB.");
                    }
                    else if (serverEmployee.LastModified > localEmployee.LastModified)
                    {
                        await _indexedDbService.UpdateEmployeeAsync(serverEmployee);
                        _logger.LogInformation($"Updated employee {serverEmployee.Id} in IndexedDB.");
                    }
                }

                foreach (var localEmployee in localEmployees)
                {
                    if (!serverEmployeeIds.Contains(localEmployee.Id))
                    {
                        await _indexedDbService.DeleteEmployeeAsync(localEmployee.Id);
                        _logger.LogInformation($"Deleted employee {localEmployee.Id} from IndexedDB.");
                    }
                }

                _logger.LogInformation("Sync from server to local database completed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during sync from server to local database.");
            }
        }

        public async Task SyncFromLocalToServer()
        {
            _logger.LogInformation("Syncing from local to server database.");
            try
            {
                var localEmployees = await _indexedDbService.GetEmployeesAsync();
                var serverEmployees = await _employeeService.GetEmployeesAsync();

                var localEmployeeIds = localEmployees.Select(e => e.Id).ToHashSet();

                foreach (var localEmployee in localEmployees)
                {
                    var serverEmployee = serverEmployees.FirstOrDefault(e => e.Id == localEmployee.Id);
                    if (serverEmployee == null)
                    {
                        await _employeeService.AddEmployeeAsync(localEmployee);
                        _logger.LogInformation($"Added employee {localEmployee.Id} to server.");
                    }
                    else if (localEmployee.LastModified > serverEmployee.LastModified)
                    {
                        await _employeeService.UpdateEmployeeAsync(localEmployee);
                        _logger.LogInformation($"Updated employee {localEmployee.Id} on server.");
                    }
                }

                foreach (var serverEmployee in serverEmployees)
                {
                    if (!localEmployeeIds.Contains(serverEmployee.Id))
                    {
                        await _employeeService.DeleteEmployeeAsync(serverEmployee.Id);
                        _logger.LogInformation($"Deleted employee {serverEmployee.Id} from server.");
                    }
                }

                _logger.LogInformation("Sync from local to server database completed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during sync from local to server database.");
            }
        }
    }
}
