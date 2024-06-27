using Employees.Data;
using Employees.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Employees.Pages
{
    public partial class IndexBase : ComponentBase
    {
        public bool ShowCreate { get; set; }
        public bool ShowEdit { get; set; }
        public int EditingId { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee NewEmployee { get; set; } = new Employee();
        public Employee EmployeeToUpdate { get; set; }
        public List<Employee> OurEmployees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowEmployees();
        }

        //------------------ Create! ----------------///

        public void ShowCreateForm()
        {
            ShowCreate = true;
            NewEmployee = new Employee();
        }

        public async Task CreateNewEmployee()
        {
            await EmployeeService.AddEmployeeAsync(NewEmployee);

            ShowCreate = false;
            await ShowEmployees();
        }

        //------------------ Read! ----------------///

        public async Task ShowEmployees()
        {
            OurEmployees = await EmployeeService.GetEmployeesAsync();
        }

        //------------------ Update! ----------------///

        public async Task ShowEditForm(Employee ourEmployee)
        {
            EmployeeToUpdate = await EmployeeService.GetEmployeeByIdAsync(ourEmployee.Id);
            ShowEdit = true;
            EditingId = ourEmployee.Id;
        }

        public async Task UpdateEmployee()
        {
            await EmployeeService.UpdateEmployeeAsync(EmployeeToUpdate);
            ShowEdit = false;
            await ShowEmployees();
        }

        //------------------ Delete! ----------------///

        public async Task DeleteEmployee(Employee ourEmployee)
        {
            await EmployeeService.DeleteEmployeeAsync(ourEmployee.Id);
            await ShowEmployees();
        }
    }
}
