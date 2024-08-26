using EmployeeManagement.Application.Mappings;
using EmployeeManagement.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application.Extensions;

public static class SeviceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var currentAssembly = typeof(EmployeeProfile).Assembly;
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ISalaryService, SalaryService>();
        
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(currentAssembly);
        });
    }
}