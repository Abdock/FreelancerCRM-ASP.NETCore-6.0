using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class FreelancerRepository : RepositoryBase<Freelancer>, IFreelancerRepository
{
    public FreelancerRepository(CrmContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersOfFreelancerAsync(Guid freelancerId)
    {
        return await Context.Freelancers
            .Where(e => e.Id == freelancerId)
            .Include(e => e.Orders)
            .SelectMany(e => e.Orders)
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetFeedbacksOfFreelancerAsync(Guid freelancerId)
    {
        return await Context.Freelancers
            .Where(e => e.Id == freelancerId)
            .Include(e => e.Feedbacks)
            .SelectMany(e => e.Feedbacks)
            .ToListAsync();
    }

    public async Task<IEnumerable<Skill>> GetSkillsOfFreelancerAsync(Freelancer freelancer)
    {
        return await Context.Freelancers
            .Where(e => e.Id == freelancer.Id)
            .Include(e => e.Skills)
            .SelectMany(e => e.Skills)
            .ToListAsync();
    }
}