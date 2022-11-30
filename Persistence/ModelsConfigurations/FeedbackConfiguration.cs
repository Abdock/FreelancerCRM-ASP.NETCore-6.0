using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelsConfigurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasOne(e => e.Client)
            .WithMany(e => e.Feedbacks);
        builder.HasOne(e => e.Freelancer)
            .WithMany(e => e.Feedbacks);
        builder.HasOne(e => e.Order)
            .WithMany(e => e.Feedbacks)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Property(e => e.Title).HasMaxLength(ConfigurationsConstants.MaxShortTextLength);
        builder.Property(e => e.Comment).HasMaxLength(ConfigurationsConstants.MaxLongTextLength);
        builder.Property(e => e.Grade)
            .HasPrecision(ConfigurationsConstants.GradePrecision, ConfigurationsConstants.GradeScale);
    }
}