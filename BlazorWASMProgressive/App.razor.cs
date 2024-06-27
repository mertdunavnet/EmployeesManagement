using BlazorWASMProgressive.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWASMProgressive
{
    public partial class App : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IServiceProvider ServiceProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                bool isOnline = await JSRuntime.InvokeAsync<bool>("checkOnlineStatus");
                HandleOnlineStatus(isOnline);

                await JSRuntime.InvokeVoidAsync("addOnlineOfflineListener", DotNetObjectReference.Create(this));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking online status: {ex.Message}");
                throw; // Throw the exception for further investigation
            }
        }

        [JSInvokable]
        public async Task HandleOnlineStatus(bool isOnline)
        {
            if (isOnline)
            {
                var syncService = ServiceProvider.GetRequiredService<DatabaseSyncService>();
                await syncService.SyncFromServerToLocal();
                //await syncService.SyncFromLocalToServer();
            }
        }
    }
}
