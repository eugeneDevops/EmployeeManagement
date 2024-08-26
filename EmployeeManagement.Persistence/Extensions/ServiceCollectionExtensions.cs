using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<EmployeeDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("BaseConnection")));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}