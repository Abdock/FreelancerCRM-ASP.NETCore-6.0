using Domain.Models;

namespace Domain.Repositories;

public interface IAdvertisementRepository : IRepository<Advertisement>
{
    Task<IEnumerable<Skill>> GetSkillsFromAdvertisementAsync(Advertisement ad);

    Task<Order> GetOrderOfAdvertisementAsync(Advertisement advertisement);

    Task<Category> GetCategoryOfAdvertisementAsync(Advertisement advertisement);

    Task<Client> GetClientOfAdvertisementAsync(Advertisement advertisement);
}