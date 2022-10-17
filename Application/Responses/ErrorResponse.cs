namespace Application.Responses;

public class ErrorResponse
{
    public int ErrorStatusCode { get; init; }
    public string ErrorMessage { get; init; } = default!;
}