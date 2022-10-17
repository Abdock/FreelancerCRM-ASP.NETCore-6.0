namespace Application.Responses;

public class FeedbackResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Comment { get; set; } = default!;
    public decimal Grade { get; set; }
    public DateTime CreationDate { get; set; }
    public FreelancerResponse Freelancer { get; set; } = default!;
    public ClientResponse Client { get; set; } = default!;
    public OrderResponse Order { get; set; } = default!;
}