using AutoMapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Application.Services;

namespace EmployeeManagement.CLI.Interfaces;

public class SalaryInterface
{
    private readonly IEmployeeService _employeeService;
    private readonly ISalaryService _salaryService;

    public SalaryInterface(IEmployeeService employeeService, ISalaryService salaryService)
    {
        _employeeService = employeeService;
        _salaryService = salaryService;
    }

    public async Task CalculateSalary()
    {
        InterfaceExtensions.ShowBeginning("Рассчет заработной платы");
        var employee = new ViewEmployee();
        var name = await InputEmployee(employee);
        if (string.IsNullOrWhiteSpace(name))
            return;
        Console.Write("Введите начало даты: ");
        var startDate = DateOnly.Parse(Console.ReadLine());
        Console.Write("Введите конец даты: ");
        var endDate = DateOnly.Parse(Console.ReadLine());
        var salary = await _salaryService.CalculateSalary(name, startDate, endDate);
        Console.WriteLine($"Рассчёт заработной платы окончен. Зарплата будет составлять - {salary}");
    }
    
    private async Task<string> InputEmployee(ViewEmployee employee)
    {
        string name;
        do
        {
            Console.Write("Введите имя пользователя: ");
            name = Console.ReadLine();
            if (name == "0")
                return name;
            employee = await _employeeService.GetEmployeeByName(name);
        } while (employee == null);
        return name;
    }
}