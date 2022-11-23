using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Base;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.Context;

namespace Persistence.Repositories;

public abstract class RepositoryBase<TDomainEntity, TPersistenceEntity> : IRepository<TDomainEntity>
    where TDomainEntity : BaseEntity where TPersistenceEntity : BasePersistenceEntity
{
    protected readonly CrmContext Context;
    protected readonly IMapper Mapper;

    protected RepositoryBase(CrmContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public async Task<TDomainEntity> GetByIdAsync(Guid id)
    {
        var entity = await Context.Set<TPersistenceEntity>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(TDomainEntity), id);
        }

        return Mapper.Map<TDomainEntity>(entity);
    }

    public IQueryable<TDomainEntity> FindByCondition(Expression<Func<TDomainEntity, bool>> predicate)
    {
        return Context.Set<TPersistenceEntity>()
            .ProjectTo<TDomainEntity>(Mapper.ConfigurationProvider)
            .Where(predicate);
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await Context.Set<TPersistenceEntity>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(TDomainEntity), id);
        }

        Context.Set<TPersistenceEntity>().Remove(entity);
    }

    public async Task<IEnumerable<TDomainEntity>> GetAllAsync()
    {
        return await Context
            .Set<TPersistenceEntity>()
            .AsSplitQuery()
            .ProjectTo<TDomainEntity>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<TDomainEntity>> GetRangeAsync(int skipCount, int takeCount)
    {
        return await Context
            .Set<TPersistenceEntity>()
            .AsSplitQuery()
            .OrderBy(e => e.Id)
            .Skip(skipCount)
            .Take(takeCount)
            .ProjectTo<TDomainEntity>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<bool> IsExistsAsync(Guid id)
    {
        return await Context.Set<TPersistenceEntity>().AnyAsync(e => e.Id == id);
    }

    public async Task<int> TotalCountAsync()
    {
        return await Context.Set<TPersistenceEntity>().CountAsync();
    }
}