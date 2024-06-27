using BlazorWASMProgressive.Data;
using System.Net.Http.Json;

namespace BlazorWASMProgressive.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeModel>>("https://localhost:7205/api/employee");
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EmployeeModel>($"https://localhost:7205/api/employee/{id}");
        }

        public async Task AddEmployeeAsync(EmployeeModel employee)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7205/api/employee", employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeModel employee)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7205/api/employee/{employee.Id}", employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7205/api/employee/{id}");
        }
    }
}
