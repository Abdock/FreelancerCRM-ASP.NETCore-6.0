﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CrmContext))]
    partial class CrmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdvertisementEntitySkillEntity", b =>
                {
                    b.Property<Guid>("AdvertisementsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AdvertisementsId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("AdvertisementEntitySkillEntity");
                });

            modelBuilder.Entity("FreelancerEntitySkillEntity", b =>
                {
                    b.Property<Guid>("FreelancersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FreelancersId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("FreelancerEntitySkillEntity");
                });

            modelBuilder.Entity("Persistence.Entities.AdvertisementEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdvertisementStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(16384)
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 3)
                        .HasColumnType("decimal(15,3)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementStatusId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Persistence.Entities.AdvertisementStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementsStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Open"
                        },
                        new
                        {
                            Id = 2,
                            Name = "InProcess"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Close"
                        });
                });

            modelBuilder.Entity("Persistence.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Persistence.Entities.ClientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Persistence.Entities.FeedbackEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Grade")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("OrderId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Persistence.Entities.FreelancerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Freelancers");
                });

            modelBuilder.Entity("Persistence.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdvertisementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("ClientEntityId");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Persistence.Entities.OrderStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("OrdersStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Completed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("Persistence.Entities.SkillEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UX_Skills_Name")
                        .IsUnique();

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("AdvertisementEntitySkillEntity", b =>
                {
                    b.HasOne("Persistence.Entities.AdvertisementEntity", null)
                        .WithMany()
                        .HasForeignKey("AdvertisementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.SkillEntity", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FreelancerEntitySkillEntity", b =>
                {
                    b.HasOne("Persistence.Entities.FreelancerEntity", null)
                        .WithMany()
                        .HasForeignKey("FreelancersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.SkillEntity", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Persistence.Entities.AdvertisementEntity", b =>
                {
                    b.HasOne("Persistence.Entities.AdvertisementStatusEntity", "AdvertisementStatus")
                        .WithMany()
                        .HasForeignKey("AdvertisementStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.CategoryEntity", "Category")
                        .WithMany("Advertisements")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.ClientEntity", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdvertisementStatus");

                    b.Navigation("Category");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Persistence.Entities.ClientEntity", b =>
                {
                    b.OwnsOne("Persistence.Entities.UserAccountEntity", "Account", b1 =>
                        {
                            b1.Property<Guid>("ClientEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.HasKey("ClientEntityId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientEntityId");
                        });

                    b.Navigation("Account")
                        .IsRequired();
                });

            modelBuilder.Entity("Persistence.Entities.FeedbackEntity", b =>
                {
                    b.HasOne("Persistence.Entities.ClientEntity", "Client")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.FreelancerEntity", "Freelancer")
                        .WithMany("Feedbacks")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.OrderEntity", "Order")
                        .WithMany("Feedbacks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Freelancer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Persistence.Entities.FreelancerEntity", b =>
                {
                    b.OwnsOne("Persistence.Entities.UserAccountEntity", "Account", b1 =>
                        {
                            b1.Property<Guid>("FreelancerEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.HasKey("FreelancerEntityId");

                            b1.ToTable("Freelancers");

                            b1.WithOwner()
                                .HasForeignKey("FreelancerEntityId");
                        });

                    b.Navigation("Account")
                        .IsRequired();
                });

            modelBuilder.Entity("Persistence.Entities.OrderEntity", b =>
                {
                    b.HasOne("Persistence.Entities.AdvertisementEntity", "Advertisement")
                        .WithMany()
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.ClientEntity", null)
                        .WithMany("Orders")
                        .HasForeignKey("ClientEntityId");

                    b.HasOne("Persistence.Entities.FreelancerEntity", "Freelancer")
                        .WithMany("Orders")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.OrderStatusEntity", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("Freelancer");

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("Persistence.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Advertisements");
                });

            modelBuilder.Entity("Persistence.Entities.ClientEntity", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Persistence.Entities.FreelancerEntity", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Persistence.Entities.OrderEntity", b =>
                {
                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
