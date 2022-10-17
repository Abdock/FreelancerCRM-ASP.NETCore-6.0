namespace Application.DTOs;

public class FeedbackDto
{
    public string Title { get; set; } = default!;
    public string Comment { get; set; } = default!;
    public ClientDto Client { get; set; } = default!;
    public FreelancerDto Freelancer { get; set; } = default!;
    public OrderDto Order { get; set; } = default!;
    public decimal Grade { get; set; }
    public DateTime CreationDate { get; set; }
}