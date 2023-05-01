using Microsoft.EntityFrameworkCore;
using SupportMVC.Models;
using SupportMVC.Models.DTO;

namespace SupportMVC.Context
{
    public class SupportContext:DbContext
    {
            public DbSet<Technology> Technologies { get; set; }
            public DbSet<Status> Statuses { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<SMEMapping> SMEMapping { get; set; }
            public DbSet<Ticket> Ticket { get; set; }

            public SupportContext(DbContextOptions<SupportContext> dbContextOptions) : base(dbContextOptions)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Technology>().HasData(
                    new Technology { TechnologyId = 1, TechnologyName = "Power Apps" },
                    new Technology { TechnologyId = 2, TechnologyName = "Power Automate" },
                    new Technology { TechnologyId = 3, TechnologyName = "PowerBI" },
                    new Technology { TechnologyId = 4, TechnologyName = "Power Automate Desktop" },
                    new Technology { TechnologyId = 5, TechnologyName = "Deployment DEV to STAGE" },
                    new Technology { TechnologyId = 6, TechnologyName = "Deployment STAGE to PROD" }
                    );
                modelBuilder.Entity<Status>().HasData(
                    new Status { StatusId = 1, StatusName = "New" },
                    new Status { StatusId = 2, StatusName = "In Progress" },
                    new Status { StatusId = 3, StatusName = "Closed" });
                modelBuilder.Entity<Role>().HasData(
                    new Role { RoleId = 1, RoleName = "User" },
                    new Role { RoleId = 2, RoleName = "SME" },
                    new Role { RoleId = 3, RoleName = "Admin" });
                modelBuilder.Entity<User>().HasData(
                    new User { UserId = 1, UserName = "Prashanth Krishna", EmailId = "udupaprashanth.b.krishna@gmail.com", EnterpriseId = "udupaprashanthkrishna", RoleId = 1 },
                new User { UserId = 2, UserName = "PK", EmailId = "prashanth.b.krishna@gmail.com", EnterpriseId = "prashanth.b.krishna", RoleId = 1 });
                modelBuilder.Entity<SMEMapping>().HasData(
                    new SMEMapping { SMEMappingId = 1, TechnologyId = 4, UserId = 1 });
                modelBuilder.Entity<Ticket>().HasData(new Ticket
                {
                    TicketId = 1,
                    RequestorUserId = 2,
                    TechnologyId = 4,
                    Query = "How to install PAD?",
                    AdditionalDetails = "NA",
                    TimeSpent = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                    StatusId = 1
                });
            }

            public DbSet<SupportMVC.Models.DTO.TicketDTO>? TicketDTO { get; set; }
        }
    }

