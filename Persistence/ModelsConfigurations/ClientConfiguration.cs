using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelsConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasMany(e => e.Orders)
            .WithOne(e => e.Client);
        builder.HasMany(e => e.Feedbacks)
            .WithOne(e => e.Client);
        builder.OwnsOne(e => e.Account, navigationBuilder =>
        {
            navigationBuilder.Property(e => e.Name).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
            navigationBuilder.Property(e => e.Surname).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
            navigationBuilder.Property(e => e.Email).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
            navigationBuilder.Property(e => e.Phone).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
        });
    }
}