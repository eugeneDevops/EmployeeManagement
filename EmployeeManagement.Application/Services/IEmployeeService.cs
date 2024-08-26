using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Application.Services;

public interface IEmployeeService
{
    Task<List<ViewEmployee>> GetEmployees();
    Task<ViewEmployee?> GetEmployeeByName(string name, CancellationToken cancellationToken = default);
    Task<ViewEmployee?> CreateEmployee(FormEmployee formEmployee, CancellationToken cancellationToken = default);
    Task<ViewEmployee?> UpdateEmployee(string name, FormEmployee formEmployee, CancellationToken cancellationToken = default);
    Task<ViewEmployee?> DeleteEmployee(string name, CancellationToken cancellationToken = default);
}