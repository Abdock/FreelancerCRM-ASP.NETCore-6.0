using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Categories")]
[Index(nameof(RowGuid), IsUnique = true, Name = "UX_Categories_RowGuid")]
public class CategoryEntity : BasePersistenceEntity
{
    public CategoryEntity()
    {
        Advertisements = new HashSet<AdvertisementEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(128)]
    public string Name { get; set; } = default!;

    public override Guid RowGuid { get; set; }
    public ICollection<AdvertisementEntity> Advertisements { get; set; }
}