﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupportMVC.Context;

#nullable disable

namespace SupportMVC.Migrations
{
    [DbContext(typeof(SupportContext))]
    [Migration("20230430144838_updatedTicket")]
    partial class updatedTicket
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SupportMVC.Models.DTO.TicketDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestorUserId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicketDTO");
                });

            modelBuilder.Entity("SupportMVC.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "User"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "SME"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("SupportMVC.Models.SMEMapping", b =>
                {
                    b.Property<int>("SMEMappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SMEMappingId"));

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SMEMappingId");

                    b.HasIndex("TechnologyId");

                    b.HasIndex("UserId");

                    b.ToTable("SMEMapping");

                    b.HasData(
                        new
                        {
                            SMEMappingId = 1,
                            TechnologyId = 4,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("SupportMVC.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "New"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "In Progress"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "Closed"
                        });
                });

            modelBuilder.Entity("SupportMVC.Models.Technology", b =>
                {
                    b.Property<int>("TechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnologyId"));

                    b.Property<string>("TechnologyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnologyId");

                    b.ToTable("Technologies");

                    b.HasData(
                        new
                        {
                            TechnologyId = 1,
                            TechnologyName = "Power Apps"
                        },
                        new
                        {
                            TechnologyId = 2,
                            TechnologyName = "Power Automate"
                        },
                        new
                        {
                            TechnologyId = 3,
                            TechnologyName = "PowerBI"
                        },
                        new
                        {
                            TechnologyId = 4,
                            TechnologyName = "Power Automate Desktop"
                        },
                        new
                        {
                            TechnologyId = 5,
                            TechnologyName = "Deployment DEV to STAGE"
                        },
                        new
                        {
                            TechnologyId = 6,
                            TechnologyName = "Deployment STAGE to PROD"
                        });
                });

            modelBuilder.Entity("SupportMVC.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("AdditionalDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuerySolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("SMEUserId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeSpent")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TicketId");

                    b.HasIndex("RequestorUserId");

                    b.HasIndex("SMEUserId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Ticket");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            AdditionalDetails = "NA",
                            CreatedAt = new DateTime(2023, 4, 30, 20, 18, 38, 379, DateTimeKind.Local).AddTicks(5656),
                            Query = "How to install PAD?",
                            QuerySolution = "",
                            RequestorUserId = 2,
                            StatusId = 1,
                            TechnologyId = 4,
                            TimeSpent = 0,
                            UpdatedAt = new DateTime(2023, 4, 30, 20, 18, 38, 379, DateTimeKind.Local).AddTicks(5670)
                        });
                });

            modelBuilder.Entity("SupportMVC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterpriseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            EmailId = "udupaprashanth.b.krishna@gmail.com",
                            EnterpriseId = "udupaprashanthkrishna",
                            RoleId = 1,
                            UserName = "Prashanth Krishna"
                        },
                        new
                        {
                            UserId = 2,
                            EmailId = "prashanth.b.krishna@gmail.com",
                            EnterpriseId = "prashanth.b.krishna",
                            RoleId = 1,
                            UserName = "PK"
                        });
                });

            modelBuilder.Entity("SupportMVC.Models.SMEMapping", b =>
                {
                    b.HasOne("SupportMVC.Models.Technology", "Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupportMVC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Technology");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SupportMVC.Models.Ticket", b =>
                {
                    b.HasOne("SupportMVC.Models.User", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupportMVC.Models.User", "SME")
                        .WithMany()
                        .HasForeignKey("SMEUserId");

                    b.HasOne("SupportMVC.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupportMVC.Models.Technology", "Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requestor");

                    b.Navigation("SME");

                    b.Navigation("Status");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("SupportMVC.Models.User", b =>
                {
                    b.HasOne("SupportMVC.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
