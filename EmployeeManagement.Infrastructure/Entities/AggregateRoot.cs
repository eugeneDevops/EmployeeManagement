namespace EmployeeManagement.Infrastructure.Entities;

public abstract class AggregateRoot
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset EditedAt { get; set; }
}