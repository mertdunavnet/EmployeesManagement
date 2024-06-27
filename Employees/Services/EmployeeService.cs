using Employees.Data;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbContextFactory<EmployeeDataContext> _contextFactory;

        public EmployeeService(IDbContextFactory<EmployeeDataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            using var context = _contextFactory.CreateDbContext();
            employee.LastModified = DateTime.UtcNow;
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            using var context = _contextFactory.CreateDbContext();
            employee.LastModified = DateTime.UtcNow;
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }
    }
}
