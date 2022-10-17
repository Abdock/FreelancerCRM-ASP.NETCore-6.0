using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Clients")]
[Index(nameof(RowGuid), IsUnique = true, Name = "UX_Clients_RowGuid")]
public class ClientEntity : BasePersistenceEntity
{
    public ClientEntity()
    {
        Orders = new HashSet<OrderEntity>();
        Feedbacks = new HashSet<FeedbackEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    public UserAccountEntity Account { get; set; } = null!;
    public override Guid RowGuid { get; set; }
    public ICollection<OrderEntity> Orders { get; set; }
    public ICollection<FeedbackEntity> Feedbacks { get; set; }
}