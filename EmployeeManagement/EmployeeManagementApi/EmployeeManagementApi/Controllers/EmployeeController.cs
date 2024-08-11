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
    //if this stays named as originally GetEmployeeByIdAsync
    //it appears it causes issues with the CreatedAtAction within the CreateEmployee method

    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
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
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        await _employeeRepository.AddEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployeeById(int id)
    {
        await _employeeRepository.DeleteEmployeeAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Employee>> UpdateEmployeeById(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }

        await _employeeRepository.UpdateEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }
}
