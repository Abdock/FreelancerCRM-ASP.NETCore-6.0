using Domain.Base;

namespace Domain.Models;

public class Feedback : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Comment { get; set; } = default!;
    public Client Client { get; set; } = default!;
    public Freelancer Freelancer { get; set; } = default!;
    public Order Order { get; set; } = default!;
    public decimal Grade { get; set; } = default!;
    public DateTime CreationDate { get; set; } = DateTime.Today;
}