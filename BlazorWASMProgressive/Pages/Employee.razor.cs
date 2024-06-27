using BlazorWASMProgressive.Data;
using BlazorWASMProgressive.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorWASMProgressive.Data;

namespace BlazorWASMProgressive.Pages
{
    public partial class Employee : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IndexedDbService IndexedDbService { get; set; }

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
            return await JSRuntime.InvokeAsync<bool>("navigator.onLine");
        }
    }
}
