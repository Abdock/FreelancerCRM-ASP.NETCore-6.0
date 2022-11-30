using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelsConfigurations;

public class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
{
    public void Configure(EntityTypeBuilder<Freelancer> builder)
    {
        builder.HasMany(e => e.Orders)
            .WithOne(e => e.Freelancer);
        builder.HasMany(e => e.Feedbacks)
            .WithOne(e => e.Freelancer);
        builder.HasMany(e => e.Skills)
            .WithMany(e => e.Freelancers);
        builder.OwnsOne(e => e.Account, navigationBuilder =>
        {
            navigationBuilder.Property(e => e.Name).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
            navigationBuilder.Property(e => e.Surname).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
            navigationBuilder.Property(e => e.Email).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
            navigationBuilder.Property(e => e.Phone).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
        });
    }
}