using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Repositories.Contracts;

public interface IEmployeeRepository
{
    //not generic yet, keeping it yet as is for this simple app
    Task<IEnumerable<Employee>> GetAllAsync();

    Task<Employee?> GetByIdAsync(int id);

    Task AddEmployeeAsync(Employee employee);

    Task UpdateEmployeeAsync(Employee employee);

    Task DeleteEmployeeAsync(int id);
}
