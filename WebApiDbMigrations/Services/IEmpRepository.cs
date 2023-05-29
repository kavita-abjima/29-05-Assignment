using WebApiDbMigrations.Models;

namespace WebApiDbMigrations.Services
{
    public interface IEmpRepository
    {
        Task<List<Employee>> GetEmployee();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> AddEmployeeAsync(Employee employee);

        Task<Employee> DeleteEmployeeAsync(int id);

        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
    }
}
