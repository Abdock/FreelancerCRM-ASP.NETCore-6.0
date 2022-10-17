using Domain.Models;

namespace Domain.Repositories;

public interface IFreelancerRepository : IRepository<Freelancer>
{
    Task<IEnumerable<Order>> GetOrdersOfFreelancerAsync(Guid freelancerId);

    Task<IEnumerable<Feedback>> GetFeedbacksOfFreelancerAsync(Guid freelancerId);

    Task<IEnumerable<Skill>> GetSkillsOfFreelancerAsync(Freelancer freelancer);

    Task AddAsync(Freelancer freelancer);
}