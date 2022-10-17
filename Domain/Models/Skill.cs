using Domain.Base;

namespace Domain.Models;

public class Skill : BaseEntity
{
    public string Name { get; set; } = default!;
    public ICollection<Freelancer> Freelancers { get; set; } = new HashSet<Freelancer>();
    public ICollection<Advertisement> Advertisements { get; set; } = new HashSet<Advertisement>();
}