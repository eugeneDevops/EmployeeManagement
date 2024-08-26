using Ardalis.Specification;
using EmployeeManagement.Domain.Aggregates;

namespace EmployeeManagement.Domain.Specifications;

public class GetEmployeesSpecification : Specification<Employee>
{
    public GetEmployeesSpecification() { }
}

public sealed class GetEmployeeByNameSpec : GetEmployeesSpecification
{
    public GetEmployeeByNameSpec(string name)
    {
        Query.Where(employee => employee.Name == name);
    }
}