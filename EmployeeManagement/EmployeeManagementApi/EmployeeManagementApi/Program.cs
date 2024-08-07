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

        builder.Services.AddCors(options =>
            options.AddPolicy("MyCors", policyBuilder =>
            {
                policyBuilder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));

        var app = builder.Build();

        app.UseCors("MyCors");

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
