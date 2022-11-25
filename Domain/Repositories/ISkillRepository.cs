using Domain.Models;

namespace Domain.Repositories;

public interface ISkillRepository : IRepository<Skill>
{
    Task<IEnumerable<Advertisement>> GetAdvertisementsWithSkillAsync(Skill skill);

    Task<IEnumerable<Freelancer>> GetFreelancersWithSkillAsync(Skill skill);
}