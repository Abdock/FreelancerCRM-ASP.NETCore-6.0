using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
{
    public SkillRepository(CrmContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Advertisement>> GetAdvertisementsWithSkillAsync(Skill skill)
    {
        return await Context.Skills
            .Where(s => s.Id == skill.Id)
            .Include(s => s.Advertisements)
            .SelectMany(s => s.Advertisements)
            .ToListAsync();
    }

    public async Task<IEnumerable<Freelancer>> GetFreelancersWithSkillAsync(Skill skill)
    {
        return await Context.Skills
            .Where(s => s.Id == skill.Id)
            .Include(s => s.Freelancers)
            .SelectMany(s => s.Freelancers)
            .ToListAsync();
    }
}