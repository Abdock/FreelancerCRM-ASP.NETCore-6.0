using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class SkillRepository : RepositoryBase<Skill, SkillEntity>, ISkillRepository
{
    public SkillRepository(CrmContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<Advertisement>> GetAdvertisementsWithSkillAsync(Skill skill)
    {
        return await Context.Skills
            .Where(s => s.Id == skill.Id)
            .Include(s => s.Advertisements)
            .SelectMany(s => s.Advertisements)
            .ProjectTo<Advertisement>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<Freelancer>> GetFreelancersWithSkillAsync(Skill skill)
    {
        return await Context.Skills
            .Where(s => s.Id == skill.Id)
            .Include(s => s.Freelancers)
            .SelectMany(s => s.Freelancers)
            .ProjectTo<Freelancer>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task AddAsync(Skill skill)
    {
        await Context.Skills.AddAsync(Mapper.Map<SkillEntity>(skill));
    }
}