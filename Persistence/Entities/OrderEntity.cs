using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Orders")]
public class OrderEntity : BasePersistenceEntity
{
    public OrderEntity()
    {
        Feedbacks = new HashSet<FeedbackEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override Guid Id { get; set; }

    [ForeignKey(nameof(OrderStatus))]
    public OrderStatus OrderStatusId { get; set; }

    [ForeignKey(nameof(Freelancer))]
    public Guid FreelancerId { get; set; }

    [ForeignKey(nameof(Advertisement))]
    public Guid AdvertisementId { get; set; }

    public ICollection<FeedbackEntity> Feedbacks { get; set; }
    public FreelancerEntity Freelancer { get; set; } = default!;
    public OrderStatusEntity OrderStatus { get; set; } = default!;
    public AdvertisementEntity Advertisement { get; set; } = default!;
}