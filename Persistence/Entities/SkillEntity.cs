using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Skills")]
[Index(nameof(Name), IsUnique = true, Name = "UX_Skills_Name")]
[Index(nameof(RowGuid), IsUnique = true, Name = "UX_Skills_RowGuid")]
public class SkillEntity : BasePersistenceEntity
{
    public SkillEntity()
    {
        Freelancers = new HashSet<FreelancerEntity>();
        Advertisements = new HashSet<AdvertisementEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(256)]
    public string Name { get; set; } = default!;

    public override Guid RowGuid { get; set; }

    public ICollection<FreelancerEntity> Freelancers { get; set; }
    public ICollection<AdvertisementEntity> Advertisements { get; set; }
}