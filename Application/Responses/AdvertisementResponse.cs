namespace Application.Responses;

public class AdvertisementResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime Deadline { get; set; }
    public ClientResponse Client { get; set; } = default!;
    public CategoryResponse Category { get; set; } = default!;
    public string Status { get; set; } = default!;
    public ICollection<SkillResponse> Skills { get; set; } = new List<SkillResponse>();
}