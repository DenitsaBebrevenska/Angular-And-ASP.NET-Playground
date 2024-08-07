using EmployeeManagementApi.Data;
using EmployeeManagementApi.Repositories;
using EmployeeManagementApi.Repositories.Contracts;
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


        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(); //lifetime scope, the scope of one http request
        //can be builder.Services.AddScoped<EmployeeRepository>(); will work but better to specify the interface
        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseCors("MyCors");

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
