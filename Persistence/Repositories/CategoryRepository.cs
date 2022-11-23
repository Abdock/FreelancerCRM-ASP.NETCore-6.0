using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class CategoryRepository : RepositoryBase<Category, CategoryEntity>, ICategoryRepository 
{
    public CategoryRepository(CrmContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<Advertisement>> GetAdvertisementsFromCategoryAsync(Category category)
    {
        return await Context.Categories
            .Where(entity => entity.Id == category.Id)
            .Include(entity => entity.Advertisements)
            .SelectMany(entity => entity.Advertisements)
            .ProjectTo<Advertisement>(Mapper.ConfigurationProvider)
            .Include(ad => ad.Client)
            .Include(ad => ad.Skills)
            .ToListAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        var entity = await Context.Categories.FirstOrDefaultAsync(e => e.Id == category.Id);
        if (entity == null)
        {
            throw new ResourceNotFoundException(nameof(Category), category.Id);
        }

        entity.Name = category.Name;
        Context.Categories.Update(entity);
    }

    public async Task AddAsync(Category category)
    {
        var entity = Mapper.Map<CategoryEntity>(category);
        await Context.Categories.AddAsync(entity);
    }
}