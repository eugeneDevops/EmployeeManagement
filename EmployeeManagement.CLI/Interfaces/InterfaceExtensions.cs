using AutoMapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Application.Services;

namespace EmployeeManagement.CLI.Interfaces;

internal static class InterfaceExtensions
{
    internal static void ShowBeginning(string text, bool showExit = true)
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine(text);
        Console.WriteLine("==================================");
        if (showExit)
            Console.WriteLine("0. Выход");
    }
    
    internal static void ShowEmployee(ViewEmployee employee)
    {
        Console.WriteLine("==================================");
        Console.WriteLine($"Сотрудник - {employee.Name}\nВозраст - {employee.Age}\nДолжность - {employee.Position}\n" +
                          $"Зарплата - {employee.Salary}\nДата приёма на работу - {employee.DateEmployment}");
        Console.WriteLine("==================================");
    }
}