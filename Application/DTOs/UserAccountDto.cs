using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class UserAccountDto
{
    public string Name { get; init; } = default!;
    public string Surname { get; init; } = default!;

    [EmailAddress]
    public string Email { get; init; } = default!;

    [Phone]
    public string Phone { get; init; } = default!;
}