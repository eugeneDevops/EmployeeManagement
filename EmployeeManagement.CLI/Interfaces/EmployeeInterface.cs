using AutoMapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Aggregates;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Specifications;

namespace EmployeeManagement.CLI.Interfaces;

public class EmployeeInterface
{
    private readonly IEmployeeService _service;
    private readonly IMapper _mapper;

    public EmployeeInterface(IEmployeeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task GetEmployees()
    {
        InterfaceExtensions.ShowBeginning("Список сотрудников", false);
        var employees = await _service.GetEmployees();
        foreach (var employee in employees) 
            InterfaceExtensions.ShowEmployee(employee);
    }

    public async Task GetEmployeeByName()
    {
        InterfaceExtensions.ShowBeginning("Вывод сотрудника по имени");
        var employee = new ViewEmployee();
        var name = await InputEmployee(employee);
        if (string.IsNullOrWhiteSpace(name))
            return;
        InterfaceExtensions.ShowEmployee(employee);
    }

    public async Task CreateEmployee()
    {
        FormEmployee formEmployee = new FormEmployee();
        InterfaceExtensions.ShowBeginning("Создание сотрудника");
        Console.Write("Введите имя: ");
        formEmployee.Name = Console.ReadLine();
        Console.WriteLine("\n");
        Console.Write("Введите возраст: ");
        formEmployee.Age = int.Parse(Console.ReadLine());
        Console.WriteLine("\n");
        Console.Write("Введите должность: ");
        formEmployee.Position = Console.ReadLine();
        Console.WriteLine("\n");
        Console.Write("Введите зарплату: ");
        formEmployee.Salary = decimal.Parse(Console.ReadLine());
        Console.WriteLine("\n");
        Console.Write("Введите дату приёма на работу: ");
        formEmployee.DateEmployment = DateOnly.Parse(Console.ReadLine());
        await _service.CreateEmployee(formEmployee);
        Console.WriteLine($"Сотрудник {formEmployee.Name} создан");
    }

    public async Task UpdateEmployee()
    {
        FormEmployee formEmployee = new FormEmployee();
        InterfaceExtensions.ShowBeginning("Редактирование сотрудника");
        var employee = new ViewEmployee();
        var name = await InputEmployee(employee);
        if (string.IsNullOrWhiteSpace(name))
            return;
        var temp = "";
        _mapper.Map(employee, formEmployee);
        while (temp != "0")
        {
            Console.WriteLine("1. Изменить имя");
            Console.WriteLine("2. Изменить возраст");
            Console.WriteLine("3. Изменить должность");
            Console.WriteLine("4. Изменить зарплату");
            Console.WriteLine("5. Изменить дату приёма на работу");
            Console.WriteLine("6. Сохранить изменения");
            Console.WriteLine();
            temp = Console.ReadLine();
            switch (temp)
            {
                case "1":
                    Console.Write("Введите имя: ");
                    formEmployee.Name = Console.ReadLine();
                    Console.WriteLine("\n");
                    break;
                case "2":
                    Console.Write("Введите возраст: ");
                    formEmployee.Age = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    break;
                case "3":
                    Console.Write("Введите должность: ");
                    formEmployee.Position = Console.ReadLine();
                    Console.WriteLine("\n");
                    break;
                case "4":
                    Console.Write("Введите зарплату: ");
                    formEmployee.Salary = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    break;
                case "5":
                    Console.Write("Введите дату приёма на работу: ");
                    formEmployee.DateEmployment = DateOnly.Parse(Console.ReadLine());
                    break;
                case "6":
                    var result = await _service.UpdateEmployee(name, formEmployee);
                    if (result == null)
                        Console.WriteLine("Ошибка при создании сотрудника.");
                    else
                        Console.WriteLine($"Пользователь {name} изменён");
                    return;
            }
        }
    }

    public async Task DeleteEmployee()
    {
        InterfaceExtensions.ShowBeginning("Удаление сотрудника");
        var employee = new ViewEmployee();
        var name = await InputEmployee(employee);
        if (string.IsNullOrWhiteSpace(name))
            return;
        await _service.DeleteEmployee(name);
        Console.WriteLine($"Пользователь {name} удалён");
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
            employee = await _service.GetEmployeeByName(name);
        } while (employee == null);
        return name;
    }
}