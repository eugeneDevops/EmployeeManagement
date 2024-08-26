using EmployeeManagement.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence;

public class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options){}
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Employee>(entity => {
            entity.HasIndex(e => e.Name).IsUnique();
        });
        builder.HasDefaultSchema("EmployeeManagement");
    }
}