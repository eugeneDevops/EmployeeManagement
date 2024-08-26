using EmployeeManagement.Infrastructure.Entities;

namespace EmployeeManagement.Domain.Aggregates;

public class Employee : AggregateRoot
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public DateOnly DateEmployment { get; set; }
}