namespace Application.Responses;

public class ClientResponse
{
    public Guid Id { get; set; }
    public UserAccountResponse Account { get; set; } = default!;
}