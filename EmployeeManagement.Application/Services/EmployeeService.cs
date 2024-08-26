using AutoMapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Domain.Aggregates;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Specifications;

namespace EmployeeManagement.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;
    
    public EmployeeService(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<ViewEmployee>> GetEmployees()
    {
        var result = new List<ViewEmployee>();
        var employees =  await _repository.FindAll();
        result = _mapper.Map<List<ViewEmployee>>(employees);
        return result;
    }

    public async Task<ViewEmployee?> GetEmployeeByName(string name, CancellationToken cancellationToken = default)
    {
        var result = new ViewEmployee();
        var spec = new GetEmployeeByNameSpec(name);
        var employee = await _repository.FirstOrDefault(spec, cancellationToken);
        if (employee == null)
        {
            Console.WriteLine("Данный сотрудник отсутствует");
            return null;
        }
        
        result = _mapper.Map<ViewEmployee>(employee);
        return result;
    }

    public async Task<ViewEmployee?> CreateEmployee(FormEmployee formEmployee, CancellationToken cancellationToken = default)
    {
        var result = new ViewEmployee();
        if (formEmployee == null || string.IsNullOrWhiteSpace(formEmployee.Name))
        {
            Console.WriteLine("Данные для изменения сотрудника отсутствуют");
            return null;
        }
        try
        {
            var employees = await _repository.FindAll();
            var nameEmployees = employees.Select(emp => emp.Name).ToList();
            if (nameEmployees.Contains(formEmployee.Name))
            {
                Console.WriteLine("Данный сотрудник уже существует в базе данных");
                return result;
            }
            
            var employee = _mapper.Map<Employee>(formEmployee);
            employee = await _repository.AddAsnyc(employee, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            result = _mapper.Map<ViewEmployee>(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании сотрудника {ex.Message}");
        }
        
        return result;
    }

    public async Task<ViewEmployee?> UpdateEmployee(string name, FormEmployee formEmployee, CancellationToken cancellationToken = default)
    {
        var result = new ViewEmployee();
        if (formEmployee == null || string.IsNullOrWhiteSpace(formEmployee.Name))
        {
            Console.WriteLine("Данные для изменения сотрудника отсутствуют");
            return null;
        }
        var spec = new GetEmployeeByNameSpec(name);
        try
        {
            var dbEmployee = await _repository.FirstOrDefault(spec, cancellationToken);
            if (dbEmployee == null)
            {
                Console.WriteLine("Данный сотрудник отсутствует");
                return null;
            }
            var employees = await _repository.FindAll();
            var nameEmployees = employees.Select(emp => emp.Name).ToList();
            if (nameEmployees.Contains(formEmployee.Name) && formEmployee.Name != dbEmployee.Name)
            {
                Console.WriteLine("Данный сотрудник уже существует в базе данных");
                return result;
            }
            
            _mapper.Map(formEmployee, dbEmployee);
            await _repository.SaveChangesAsync(cancellationToken);
            result = _mapper.Map<ViewEmployee>(dbEmployee);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при изменении сотрудника {ex.Message}");
        }
        
        return result;
    }

    public async Task<ViewEmployee?> DeleteEmployee(string name, CancellationToken cancellationToken = default)
    {
        var result = new ViewEmployee();
        var spec = new GetEmployeeByNameSpec(name);
        try
        {
            var employee = await _repository.FirstOrDefault(spec, cancellationToken);
            if (employee == null)
            {
                Console.WriteLine("Данный сотрудник отсутствует");
                return null;
            }
            
            employee = await _repository.DeleteAsync(employee.Id, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            result = _mapper.Map<ViewEmployee>(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении сотрудника {ex.Message}");
        }
        
        return result;
    }
}