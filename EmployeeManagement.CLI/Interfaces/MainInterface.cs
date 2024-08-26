namespace EmployeeManagement.CLI.Interfaces;

public class MainInterface
{
    private readonly SalaryInterface _salaryInterface;
    private readonly EmployeeInterface _employeeInterface;

    public MainInterface(SalaryInterface salaryInterface, EmployeeInterface employeeInterface)
    {
        _salaryInterface = salaryInterface;
        _employeeInterface = employeeInterface;
    }
    public async Task StartApplication()
    {
        Console.WriteLine("CLI приложение для управления сотрудниками в компании.");
        Console.WriteLine("==================================");
        Console.WriteLine("1. Добавить нового сотрудника");
        Console.WriteLine("2. Просмотреть список сотрудников");
        Console.WriteLine("3. Поиск сотрудника по имени");
        Console.WriteLine("4. Обновить данные сотрудника");
        Console.WriteLine("5. Удалить сотрудника");
        Console.WriteLine("6. Рассчет заработной платы");
        Console.WriteLine("0. Выход");
        Console.WriteLine("==================================");
        Console.Write("Введите номер операции: ");
        var resultExpession = "";
        while (resultExpession != "0")
        {
            resultExpession = Console.ReadLine();
            switch (resultExpession)
            {
                case "0":
                    break;
                case "1":
                    await _employeeInterface.CreateEmployee();
                    break;
                case "2":
                    await _employeeInterface.GetEmployees();
                    break;
                case "3":
                    await _employeeInterface.GetEmployeeByName();
                    break;
                case "4":
                    await _employeeInterface.UpdateEmployee();
                    break;
                case "5":
                    await _employeeInterface.DeleteEmployee();
                    break;
                case "6":
                    await _salaryInterface.CalculateSalary();
                    break;
            }
        }
    }
}