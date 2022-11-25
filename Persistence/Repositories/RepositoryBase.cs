using System.Linq.Expressions;
using Domain.Base;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly CrmContext Context;

    protected RepositoryBase(CrmContext context)
    {
        Context = context;
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(TEntity), id);
        }

        return entity;
    }

    public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>()
            .Where(predicate);
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(TEntity), id);
        }

        Context.Set<TEntity>().Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context
            .Set<TEntity>()
            .ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetRangeAsync(int skipCount, int takeCount)
    {
        return await Context
            .Set<TEntity>()
            .OrderBy(e => e.Id)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync();
    }

    public async Task<bool> IsExistsAsync(Guid id)
    {
        return await Context.Set<TEntity>().AnyAsync(e => e.Id == id);
    }

    public async Task<int> TotalCountAsync()
    {
        return await Context.Set<TEntity>().CountAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }
}