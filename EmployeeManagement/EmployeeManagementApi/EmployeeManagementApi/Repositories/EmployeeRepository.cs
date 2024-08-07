using EmployeeManagementApi.Data;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToArrayAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {

    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }
}
