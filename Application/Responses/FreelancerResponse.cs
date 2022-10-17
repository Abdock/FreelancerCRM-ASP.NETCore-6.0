namespace Application.Responses;

public class FreelancerResponse
{
    public Guid Id { get; set; }
    public UserAccountResponse Account { get; set; } = default!;
}