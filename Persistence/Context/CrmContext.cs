using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.ModelsConfigurations;

namespace Persistence.Context;

public class CrmContext : DbContext
{
    protected CrmContext()
    {
    }

    public CrmContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<Feedback> Feedbacks { get; set; } = default!;
    public DbSet<Freelancer> Freelancers { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<Skill> Skills { get; set; } = default!;
    public DbSet<Advertisement> Advertisements { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new FreelancerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}