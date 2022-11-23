using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Categories")]
public class CategoryEntity : BasePersistenceEntity
{
    public CategoryEntity()
    {
        Advertisements = new HashSet<AdvertisementEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override Guid Id { get; set; }

    [MaxLength(128)]
    public string Name { get; set; } = default!;

    public ICollection<AdvertisementEntity> Advertisements { get; set; }
}