namespace EmployeeManagement.Application.Services;

public interface ISalaryService
{
    Task<decimal> CalculateSalary(string name, DateOnly startDate, DateOnly endDate);
}