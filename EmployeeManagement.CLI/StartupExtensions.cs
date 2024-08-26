using EmployeeManagement.Application.Extensions;
using EmployeeManagement.CLI.Interfaces;
using EmployeeManagement.Persistence.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.CLI;

public static class StartupExtensions
{
    private static IServiceCollection _service = new ServiceCollection();
    public static void ConfigureServices()
    {
        _service.AddApplicationServices();
        _service.AddTransient<EmployeeInterface>();
        _service.AddTransient<SalaryInterface>();
        _service.AddTransient<MainInterface>();
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        _service.AddPersistenceService(configuration);
    }

    public static async Task BuildApplication()
    {
        var serviceProvider = _service.BuildServiceProvider();
        var mainInterface = serviceProvider.GetRequiredService<MainInterface>();
        await mainInterface.StartApplication();
    }
}