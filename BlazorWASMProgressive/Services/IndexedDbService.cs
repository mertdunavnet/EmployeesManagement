using Blazored.LocalStorage;
using BlazorWASMProgressive.Data;
using Microsoft.JSInterop;

namespace BlazorWASMProgressive.Services
{
    public class IndexedDbService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly ILogger<IndexedDbService> _logger;

        public IndexedDbService(IJSRuntime jsRuntime, ILogger<IndexedDbService> logger)
        {
            _jsRuntime = jsRuntime;
            this._logger = logger;
        }

        public async Task AddEmployeeAsync(EmployeeModel employee)
        {
            employee.LastModified = DateTime.UtcNow;
            await _jsRuntime.InvokeVoidAsync("indexedDBOperations.addEmployee", employee);
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            return await _jsRuntime.InvokeAsync<List<EmployeeModel>>("indexedDBOperations.getEmployees");
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            return await _jsRuntime.InvokeAsync<EmployeeModel>("indexedDBOperations.getEmployeeById", id);
        }

        public async Task UpdateEmployeeAsync(EmployeeModel employee)
        {
            employee.LastModified = DateTime.UtcNow;
            await _jsRuntime.InvokeVoidAsync("indexedDBOperations.updateEmployee", employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _jsRuntime.InvokeVoidAsync("indexedDBOperations.deleteEmployee", id);
        }
    }
}
