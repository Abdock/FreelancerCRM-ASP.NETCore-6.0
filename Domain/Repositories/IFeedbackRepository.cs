using Domain.Models;

namespace Domain.Repositories;

public interface IFeedbackRepository : IRepository<Feedback>
{
    Task<Order> GetOrderFromFeedbackAsync(Feedback feedback);

    Task<Client> GetAuthorOfFeedbackAsync(Feedback feedback);

    Task<Freelancer> GetFreelancerOfFeedbackAsync(Feedback feedback);

    Task<Advertisement> GetAdvertisementFromFeedbackAsync(Feedback feedback);
}