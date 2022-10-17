using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Context;

public class CrmContext : DbContext
{
    protected CrmContext()
    {
    }

    public CrmContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; } = default!;
    public DbSet<ClientEntity> Clients { get; set; } = default!;
    public DbSet<FeedbackEntity> Feedbacks { get; set; } = default!;
    public DbSet<FreelancerEntity> Freelancers { get; set; } = default!;
    public DbSet<OrderEntity> Orders { get; set; } = default!;
    public DbSet<OrderStatusEntity> OrdersStatuses { get; set; } = default!;
    public DbSet<SkillEntity> Skills { get; set; } = default!;
    public DbSet<AdvertisementEntity> Advertisements { get; set; } = default!;
    public DbSet<AdvertisementStatusEntity> AdvertisementsStatuses { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<OrderStatusEntity>()
            .Property(e => e.Id)
            .HasConversion<int>();
        modelBuilder
            .Entity<OrderEntity>()
            .Property(e => e.OrderStatusId)
            .HasConversion<int>();
        modelBuilder
            .Entity<OrderStatusEntity>()
            .HasData(
                Enum.GetValues<OrderStatus>()
                    .Select(e => new
                    {
                        Id = e,
                        Name = e.ToString()
                    })
            );

        modelBuilder
            .Entity<AdvertisementStatusEntity>()
            .Property(e => e.Id)
            .HasConversion<int>();
        modelBuilder
            .Entity<AdvertisementEntity>()
            .Property(dst => dst.AdvertisementStatusId)
            .HasConversion<int>();
        modelBuilder
            .Entity<AdvertisementStatusEntity>()
            .HasData(
                Enum.GetValues<AdvertisementStatus>()
                    .Select(e => new
                    {
                        Id = e,
                        Name = e.ToString()
                    })
            );
        modelBuilder.Entity<FeedbackEntity>()
            .HasOne(e => e.Order)
            .WithMany(e => e.Feedbacks)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.NoAction);
        base.OnModelCreating(modelBuilder);
    }
}