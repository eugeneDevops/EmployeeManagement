namespace EmployeeManagement.Application.Models;

public class ViewEmployee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public DateOnly DateEmployment { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset EditedAt { get; set; }
}