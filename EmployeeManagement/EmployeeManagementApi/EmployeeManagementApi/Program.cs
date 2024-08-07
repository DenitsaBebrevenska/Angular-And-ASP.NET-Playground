using EmployeeManagementApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(
            options => options.UseInMemoryDatabase("EmployeeDb"));

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
