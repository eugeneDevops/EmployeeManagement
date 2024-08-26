using AutoMapper;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Specifications;

namespace EmployeeManagement.Application.Services;

public class SalaryService : ISalaryService
{
    private readonly IEmployeeRepository _repository;
    
    public SalaryService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<decimal> CalculateSalary(string name, DateOnly startDate, DateOnly endDate)
    {
        var result = 0m;
        var spec = new GetEmployeeByNameSpec(name);
        var employee = await _repository.FirstOrDefault(spec);
        if (employee == null)
            return result;
        var salary = employee.Salary;
        var countDays = CalculateCountDays(startDate, endDate);
        return salary * countDays;
    }

    private int CalculateCountDays(DateOnly startDate, DateOnly endDate)
    {
        var countDay = 0;
        for (; startDate < endDate; startDate = startDate.AddDays(1))
        {
            if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                countDay++;
        }
        return countDay;
    }
}