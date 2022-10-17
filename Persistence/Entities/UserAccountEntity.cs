using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Entities;

[Owned]
public class UserAccountEntity
{
    [MaxLength(128)]
    public string Name { get; set; } = default!;

    [MaxLength(128)]
    public string Surname { get; set; } = default!;

    [MaxLength(128)]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [MaxLength(64)]
    [Phone]
    public string Phone { get; set; } = default!;
}