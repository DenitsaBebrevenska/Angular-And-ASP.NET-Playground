using EmployeeManagementApi.Models;
using EmployeeManagementApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository repository)
    {
        _employeeRepository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
        return Created();
    }
}
