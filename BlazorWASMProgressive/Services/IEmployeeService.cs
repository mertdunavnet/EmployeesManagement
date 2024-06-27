using BlazorWASMProgressive.Data;

namespace BlazorWASMProgressive.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeModel employee);
        Task UpdateEmployeeAsync(EmployeeModel employee);
        Task DeleteEmployeeAsync(int id);
    }
}
