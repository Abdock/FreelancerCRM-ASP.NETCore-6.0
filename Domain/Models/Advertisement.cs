using Domain.Base;
using Domain.Enums;

namespace Domain.Models;

public class Advertisement : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public DateTime CreationDate { get; } = DateTime.Today;
    public DateTime Deadline { get; set; } = default!;
    public Client Client { get; set; } = default!;
    public Category Category { get; set; } = default!;
    public ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
    public AdvertisementStatusId Status { get; set; }
}