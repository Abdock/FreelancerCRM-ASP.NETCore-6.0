using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class FreelancerRepository : RepositoryBase<Freelancer, FreelancerEntity>, IFreelancerRepository
{
    public FreelancerRepository(CrmContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersOfFreelancerAsync(Guid freelancerId)
    {
        return await Context.Freelancers
            .Where(e => e.Id == freelancerId)
            .Include(e => e.Orders)
            .SelectMany(e => e.Orders)
            .ProjectTo<Order>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetFeedbacksOfFreelancerAsync(Guid freelancerId)
    {
        return await Context.Freelancers
            .Where(e => e.Id == freelancerId)
            .Include(e => e.Feedbacks)
            .SelectMany(e => e.Feedbacks)
            .ProjectTo<Feedback>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<Skill>> GetSkillsOfFreelancerAsync(Freelancer freelancer)
    {
        return await Context.Freelancers
            .Where(e => e.Id == freelancer.Id)
            .Include(e => e.Skills)
            .SelectMany(e => e.Skills)
            .ProjectTo<Skill>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task AddAsync(Freelancer freelancer)
    {
        var skillsIds = freelancer.Skills.Select(skill => skill.Id).ToHashSet();
        var createdSkills = await Context.Skills.Where(skill => skillsIds.Contains(skill.Id)).ToListAsync();
        var entity = Mapper.Map<FreelancerEntity>(freelancer);
        var newSkills = freelancer.Skills
            .Where(newSkill => createdSkills.All(oldSkill => oldSkill.Id != newSkill.Id))
            .Select(skill => Mapper.Map<SkillEntity>(skill))
            .ToList();
        createdSkills.AddRange(newSkills);
        entity.Skills = createdSkills;
        await Context.Freelancers.AddAsync(entity);
    }
}