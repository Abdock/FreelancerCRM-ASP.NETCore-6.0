using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelsConfigurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
        builder.HasMany(e => e.Freelancers).WithMany(e => e.Skills);
        builder.HasMany(e => e.Advertisements).WithMany(e => e.Skills);
    }
}