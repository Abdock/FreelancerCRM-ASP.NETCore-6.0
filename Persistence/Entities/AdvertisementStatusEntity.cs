using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Persistence.Entities;

public class AdvertisementStatusEntity
{
    public AdvertisementStatus Id { get; set; }

    [MaxLength(32)]
    public string Name { get; set; } = default!;
}