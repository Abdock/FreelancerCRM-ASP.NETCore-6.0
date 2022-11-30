using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelsConfigurations;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        builder.Property(e => e.Title).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
        builder.Property(e => e.Description).HasMaxLength(ConfigurationsConstants.MaxLongTextLength);
        builder.Property(e => e.Price).HasPrecision(ConfigurationsConstants.PricePrecision, ConfigurationsConstants.PriceScale);
        builder.HasOne(e => e.Category)
            .WithMany(e => e.Advertisements);
        builder.HasOne(e => e.Client);
        builder.HasMany(e => e.Skills)
            .WithMany(e => e.Advertisements);
        builder.HasOne(e => e.Order)
            .WithOne(e => e.Advertisement)
            .HasForeignKey<Advertisement>(e => e.OrderId);
    }
}