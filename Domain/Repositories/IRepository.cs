using System.Linq.Expressions;
using Domain.Base;

namespace Domain.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetByIdAsync(Guid id);

    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate);

    Task RemoveAsync(Guid id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> GetRangeAsync(int skipCount, int takeCount);

    Task<bool> IsExistsAsync(Guid id);

    Task<int> TotalCountAsync();

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);
}