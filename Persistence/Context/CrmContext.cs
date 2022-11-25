using Domain.Models;
using Microsoft.EntityFrameworkCore;

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
        modelBuilder.Entity<Feedback>()
            .HasOne(e => e.Order)
            .WithMany(e => e.Feedbacks)
            .OnDelete(DeleteBehavior.NoAction);
        base.OnModelCreating(modelBuilder);
    }
}