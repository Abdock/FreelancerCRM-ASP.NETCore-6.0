using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Clients")]
public class ClientEntity : BasePersistenceEntity
{
    public ClientEntity()
    {
        Orders = new HashSet<OrderEntity>();
        Feedbacks = new HashSet<FeedbackEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override Guid Id { get; set; }
    public UserAccountEntity Account { get; set; } = null!;
    public ICollection<OrderEntity> Orders { get; set; }
    public ICollection<FeedbackEntity> Feedbacks { get; set; }
}