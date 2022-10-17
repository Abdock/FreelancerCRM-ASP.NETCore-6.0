namespace Application.Responses;

public class OrderResponse
{
    public Guid Id { get; set; }
    public AdvertisementResponse Advertisement { get; set; } = default!;
    public FreelancerResponse Freelancer { get; set; } = default!;
    public string Status { get; set; } = default!;
}