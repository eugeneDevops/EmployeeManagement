using EmployeeManagement.CLI;

public class Program
{
    public static async Task Main(string[] args)
    {
        StartupExtensions.ConfigureServices();
        await StartupExtensions.BuildApplication();
    }
}