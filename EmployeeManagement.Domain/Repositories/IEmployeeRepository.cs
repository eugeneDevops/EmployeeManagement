using EmployeeManagement.Domain.Aggregates;
using EmployeeManagement.Infrastructure.Repositories;

namespace EmployeeManagement.Domain.Repositories;

public interface IEmployeeRepository : IEntityRepository<Employee>
{
    
}