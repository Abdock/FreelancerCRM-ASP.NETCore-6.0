using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelsConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
        builder.HasMany(e => e.Advertisements)
            .WithOne(e => e.Category);
    }
}