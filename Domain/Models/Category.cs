using Domain.Base;

namespace Domain.Models;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public ICollection<Advertisement> Advertisements { get; set; } = new HashSet<Advertisement>();
}