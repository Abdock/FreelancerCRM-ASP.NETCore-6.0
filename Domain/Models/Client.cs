using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Models;

public class Client : BaseEntity
{
    public UserAccount Account { get; init; } = default!;
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
}