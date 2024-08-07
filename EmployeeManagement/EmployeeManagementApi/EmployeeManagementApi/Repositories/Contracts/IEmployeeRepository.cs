using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Repositories.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();

    Task<Employee> GetByIdAsync(int id);

    Task AddEmployeeAsync(Employee employee);

    Task UpdateEmployeeAsync(Employee employee);

    Task DeleteEmployeeAsync(int id);
}
