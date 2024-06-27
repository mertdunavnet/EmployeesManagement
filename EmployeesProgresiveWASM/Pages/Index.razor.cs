using EmployeesProgresiveWASM.Data;
using EmployeesProgresiveWASM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EmployeesProgresiveWASM.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IndexedDbService IndexedDbService { get; set; }

        [Inject]
        private DatabaseSyncService DatabaseSyncService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public bool ShowCreate { get; set; }
        public bool ShowEdit { get; set; }
        public int EditingId { get; set; }

        public EmployeeModel NewEmployee { get; set; } = new EmployeeModel();
        public EmployeeModel EmployeeToUpdate { get; set; }
        public List<EmployeeModel> OurEmployees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await DatabaseSyncService.StartAsync(default);
            await ShowEmployees();
        }

        public void ShowCreateForm()
        {
            ShowCreate = true;
            NewEmployee = new EmployeeModel();
        }

        public async Task CreateNewEmployee()
        {
            if (await IsOnline())
            {
                await EmployeeService.AddEmployeeAsync(NewEmployee);
            }
            else
            {
                await IndexedDbService.AddEmployeeAsync(NewEmployee);
            }

            ShowCreate = false;
            await ShowEmployees();
        }

        public async Task ShowEmployees()
        {
            if (await IsOnline())
            {
                OurEmployees = await EmployeeService.GetEmployeesAsync();
            }
            else
            {
                OurEmployees = await IndexedDbService.GetEmployeesAsync();
            }
        }

        public async Task ShowEditForm(EmployeeModel ourEmployee)
        {
            if (await IsOnline())
            {
                EmployeeToUpdate = await EmployeeService.GetEmployeeByIdAsync(ourEmployee.Id);
            }
            else
            {
                EmployeeToUpdate = await IndexedDbService.GetEmployeeByIdAsync(ourEmployee.Id);
            }
            ShowEdit = true;
            EditingId = ourEmployee.Id;
        }

        public async Task UpdateEmployee()
        {
            if (await IsOnline())
            {
                await EmployeeService.UpdateEmployeeAsync(EmployeeToUpdate);
            }
            else
            {
                await IndexedDbService.UpdateEmployeeAsync(EmployeeToUpdate);
            }
            ShowEdit = false;
            await ShowEmployees();
        }

        public async Task DeleteEmployee(EmployeeModel ourEmployee)
        {
            if (await IsOnline())
            {
                await EmployeeService.DeleteEmployeeAsync(ourEmployee.Id);
            }
            else
            {
                await IndexedDbService.DeleteEmployeeAsync(ourEmployee.Id);
            }
            await ShowEmployees();
        }

        private async Task<bool> IsOnline()
        {
            bool isOnline = await JSRuntime.InvokeAsync<bool>("checkOnlineStatus");
            return isOnline;
        }
    }
}
