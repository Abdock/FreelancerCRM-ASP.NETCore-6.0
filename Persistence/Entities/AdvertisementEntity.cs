using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Advertisements")]
[Index(nameof(RowGuid), IsUnique = true, Name = "UX_Advertisements_RowGuid")]
public class AdvertisementEntity : BasePersistenceEntity
{
    public AdvertisementEntity()
    {
        Skills = new HashSet<SkillEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(512)]
    public string Title { get; set; } = default!;

    [MaxLength(16384)]
    public string Description { get; set; } = default!;

    [Precision(15, 3)]
    public decimal Price { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime Deadline { get; set; }

    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }

    public ICollection<SkillEntity> Skills { get; set; }
    public override Guid RowGuid { get; set; }

    [ForeignKey(nameof(AdvertisementStatus))]
    public AdvertisementStatus AdvertisementStatusId { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public AdvertisementStatusEntity AdvertisementStatus { get; set; } = default!;

    public ClientEntity Client { get; set; } = default!;

    public CategoryEntity Category { get; set; } = default!;
}