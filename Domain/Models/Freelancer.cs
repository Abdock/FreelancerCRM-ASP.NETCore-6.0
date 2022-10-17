using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Models;

public class Freelancer : BaseEntity
{
    public UserAccount Account { get; init; } = default!;
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
    public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
}