using Domain.Base;
using Domain.Enums;

namespace Domain.Models;

public class Order : BaseEntity
{
    public Order()
    {
        Feedbacks = new HashSet<Feedback>();
    }

    public Advertisement Advertisement { get; set; } = default!;
    public OrderStatus Status { get; set; } = OrderStatus.InProgress;
    public Freelancer Freelancer { get; set; } = default!;
    public ICollection<Feedback> Feedbacks { get; set; }
}