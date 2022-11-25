using Domain.Models;

namespace Domain.Repositories;

public interface IClientRepository : IRepository<Client>
{
    Task<IEnumerable<Order>> GetAllOrdersFromClientAsync(Guid id);

    Task<IEnumerable<Feedback>> GetAllFeedbacksFromClientAsync(Guid id);
}