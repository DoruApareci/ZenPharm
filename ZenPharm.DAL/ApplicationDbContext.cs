using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
                new IdentityRole { Name = "Buyer", NormalizedName = "BUYER" },
                new IdentityRole { Name = "Moderator", NormalizedName = "MODERATOR" },
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
            );
    }
}
