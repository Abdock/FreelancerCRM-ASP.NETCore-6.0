using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Orders")]
[Index(nameof(RowGuid), IsUnique = true, Name = "UX_Orders_RowGuid")]
public class OrderEntity : BasePersistenceEntity
{
    public OrderEntity()
    {
        Feedbacks = new HashSet<FeedbackEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    public override Guid RowGuid { get; set; }

    [ForeignKey(nameof(OrderStatus))]
    public OrderStatus OrderStatusId { get; set; }

    [ForeignKey(nameof(Freelancer))]
    public int FreelancerId { get; set; }

    [ForeignKey(nameof(Advertisement))]
    public int AdvertisementId { get; set; }

    public ICollection<FeedbackEntity> Feedbacks { get; set; }
    public FreelancerEntity Freelancer { get; set; } = default!;
    public OrderStatusEntity OrderStatus { get; set; } = default!;
    public AdvertisementEntity Advertisement { get; set; } = default!;
}