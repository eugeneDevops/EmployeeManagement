using EmployeeManagement.Domain.Aggregates;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Infrastructure.Repositories;

namespace EmployeeManagement.Persistence.Repositories;

public class EmployeeRepository : EntityRepository<Employee, EmployeeDbContext>, IEmployeeRepository
{
    public EmployeeRepository(EmployeeDbContext context) : base(context)
    {
    }
}