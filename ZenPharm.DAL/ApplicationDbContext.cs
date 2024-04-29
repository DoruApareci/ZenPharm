using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ZenPharm.DAL.Models;

namespace ZenPharm.DAL;

public class ApplicationDbContext : IdentityDbContext<ZenPharmUser>
{
    private readonly string? _connectionString;

    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }

    public ApplicationDbContext(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));

        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = _connectionString };
        var connectionString = connectionStringBuilder.ToString();
        var connection = new SqliteConnection(connectionString);
        opBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole { Id = Guid.Parse("1f92b138-a27e-44cd-904e-7c10eff9616e").ToString(), Name = "Buyer", NormalizedName = "BUYER" },
                new IdentityRole { Id = Guid.Parse("af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5").ToString(), Name = "Moderator", NormalizedName = "MODERATOR" },
                new IdentityRole { Id = Guid.Parse("58ff34ee-ed69-4d43-9124-53ac00c07c85").ToString(), Name = "Admin", NormalizedName = "ADMIN" }
            );
        PasswordHasher<ZenPharmUser> hasher = new();
        modelBuilder.Entity<ZenPharmUser>()
            .HasData(
                new ZenPharmUser
                {
                    Id = Guid.Parse("e6452a0c-6887-4255-a10e-858e857ab2ed").ToString(),
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@admin.com1"),
                    FirstName = "AdminFirstName",
                    LastName = "AdminLastName",
                    Address = "AdminAddress"
                },
                new ZenPharmUser
                {
                    Id = Guid.Parse("40d18e53-8fdc-442b-894c-1537e18ee9c0").ToString(),
                    UserName = "manager@manager.com",
                    NormalizedUserName = "MANAGER@MANAGER.COM",
                    Email = "manager@manager.com",
                    NormalizedEmail = "MANAGER@MANAGER.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Manager@manager.com1"),
                    FirstName = "ManagerFirstName",
                    LastName = "ManagerLastName",
                    Address = "ManagerAddress"
                },
                new ZenPharmUser
                {
                    Id = Guid.Parse("a0b0cd50-7fac-4b4c-9a31-0967103dcb1e").ToString(),
                    UserName = "buyer@buyer.com",
                    NormalizedUserName = "BUYER@BUYER.COM",
                    Email = "buyer@buyer.com",
                    NormalizedEmail = "BUYER@BUYER.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Buyer@buyer.com1"),
                    FirstName = "BuyerFirstName",
                    LastName = "BuyerLastName",
                    Address = "BuyerAddress"
                });
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = Guid.Parse("e6452a0c-6887-4255-a10e-858e857ab2ed").ToString(), RoleId = Guid.Parse("58ff34ee-ed69-4d43-9124-53ac00c07c85").ToString() }, // Admin
            new IdentityUserRole<string> { UserId = Guid.Parse("40d18e53-8fdc-442b-894c-1537e18ee9c0").ToString(), RoleId = Guid.Parse("af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5").ToString() }, // Moderator
            new IdentityUserRole<string> { UserId = Guid.Parse("a0b0cd50-7fac-4b4c-9a31-0967103dcb1e").ToString(), RoleId = Guid.Parse("1f92b138-a27e-44cd-904e-7c10eff9616e").ToString() }  // Buyer
        );
    }
}
