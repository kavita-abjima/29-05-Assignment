using Microsoft.EntityFrameworkCore;
using WebApiDbMigrations.Data;
using WebApiDbMigrations.Models;

namespace WebApiDbMigrations.Services
{
    public class Repository:IEmpRepository
    {
        private readonly WebApiDbMigrationsContext _Context;

        public Repository(WebApiDbMigrationsContext Context)
        {
            _Context = Context;
        }


        public async Task<List<Employee>> GetEmployee()
        {
            return await _Context.Employee.ToListAsync();

        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _Context.Employee.FindAsync(id);
            return employee;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _Context.Employee.Add(employee);
            var s = await _Context.SaveChangesAsync();


            return employee;
        }
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var employeeQuery = await GetEmployeeById(id);
            if (employeeQuery == null)
            {
                return employeeQuery;
            }

            _Context.Entry(employeeQuery).CurrentValues.SetValues(employee);
            await _Context.SaveChangesAsync();

            return employeeQuery;
        }


        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee == null)
            {
                return employee;
            }
            _Context.Employee.Remove(employee);
            await _Context.SaveChangesAsync();

            return employee;
        }

    }
}
