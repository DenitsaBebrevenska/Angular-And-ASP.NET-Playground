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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
    {
        return Ok(await _employeeRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(int id)
    {
        var employeeInDb = await _employeeRepository.GetByIdAsync(id);

        if (employeeInDb == null)
        {
            return NotFound();
        }

        return Ok(employeeInDb);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { id = employee.Id });
    }
}
