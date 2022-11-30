using Domain.Base;
using Domain.Enums;

namespace Domain.Models;

public class Order : BaseEntity
{
    public Order()
    {
        Feedbacks = new HashSet<Feedback>();
    }

    public Guid AdvertisementId { get; set; }
    public Advertisement Advertisement { get; set; } = default!;
    public OrderStatusId Status { get; set; } = OrderStatusId.InProgress;
    public Freelancer Freelancer { get; set; } = default!;
    public Client Client { get; set; } = default!;
    public ICollection<Feedback> Feedbacks { get; set; }
}