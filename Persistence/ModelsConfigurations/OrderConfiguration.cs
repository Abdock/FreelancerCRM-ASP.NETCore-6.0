using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelsConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(e => e.Client)
            .WithMany(e => e.Orders);
        builder.HasOne(e => e.Freelancer)
            .WithMany(e => e.Orders);
        builder.HasOne(e => e.Advertisement)
            .WithOne(e => e.Order)
            .HasForeignKey<Order>(e => e.AdvertisementId);
        builder.HasMany(e => e.Feedbacks)
            .WithOne(e => e.Order);
    }
}