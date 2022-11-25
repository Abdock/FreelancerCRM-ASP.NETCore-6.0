using Domain.Models;

namespace Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<Client> GetClientOfOrderAsync(Order order);

    Task<Freelancer> GetFreelancerOfOrderAsync(Order order);

    Task<IEnumerable<Feedback>> GetFeedbacksFromOrderAsync(Order order);
}