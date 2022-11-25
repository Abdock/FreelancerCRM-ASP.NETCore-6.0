using Domain.Models;

namespace Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Advertisement>> GetAdvertisementsFromCategoryAsync(Category category);
}