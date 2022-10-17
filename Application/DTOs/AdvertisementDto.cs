namespace Application.DTOs;

public class AdvertisementDto
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime Deadline { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ClientId { get; set; }
    public ICollection<CreatedSkillDto> Skills { get; set; } = new List<CreatedSkillDto>();
}