namespace EmployeeManagement.Application.Models;

public class FormEmployee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public DateOnly DateEmployment { get; set; }
}