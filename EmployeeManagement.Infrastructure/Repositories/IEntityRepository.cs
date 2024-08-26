using Ardalis.Specification;
using EmployeeManagement.Infrastructure.Entities;

namespace EmployeeManagement.Infrastructure.Repositories;

public interface IEntityRepository<TEntity> where TEntity : AggregateRoot
{
    Task<List<TEntity>> FindAll(CancellationToken cancellationToken = default);
    Task<List<TEntity>> FindAll(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
    Task<List<TEntity>> FindByIds(List<Guid> ids, CancellationToken cancellationToken = default);
    Task<List<TEntity>> FindByIds(List<Guid> ids, Specification<TEntity> spec,
        CancellationToken cancellationToken = default);
    Task<TEntity> FindById(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity> FindById(Guid id, Specification<TEntity> spec, CancellationToken cancellationToken = default);
    Task<TEntity> FirstOrDefault(Specification<TEntity> spec, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsnyc(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsnyc(Guid id, TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}