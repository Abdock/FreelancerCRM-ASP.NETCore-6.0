using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Skills")]
[Index(nameof(Name), IsUnique = true, Name = "UX_Skills_Name")]
public class SkillEntity : BasePersistenceEntity
{
    public SkillEntity()
    {
        Freelancers = new HashSet<FreelancerEntity>();
        Advertisements = new HashSet<AdvertisementEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override Guid Id { get; set; }

    [MaxLength(256)]
    public string Name { get; set; } = default!;

    public ICollection<FreelancerEntity> Freelancers { get; set; }
    public ICollection<AdvertisementEntity> Advertisements { get; set; }
}