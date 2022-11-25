using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(CrmContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Advertisement>> GetAdvertisementsFromCategoryAsync(Category category)
    {
        return await Context.Categories
            .Where(entity => entity.Id == category.Id)
            .Include(entity => entity.Advertisements)
            .SelectMany(entity => entity.Advertisements)
            .Include(ad => ad.Client)
            .Include(ad => ad.Skills)
            .ToListAsync();
    }
}