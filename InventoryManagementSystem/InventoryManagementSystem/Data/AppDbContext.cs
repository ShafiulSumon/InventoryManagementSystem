using InventoryManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductEntity>().HasData(
            new  ProductEntity
            {
                Id = 1,
                Name = "Ice-Cream",
                Category = Category.Food,
                Price = 20.00M,
                Quantity = 2,
                CreatedAt = new DateTime(2025, 6, 22, 0 , 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 6, 22, 0 , 0, 0, DateTimeKind.Utc),
            },
            new  ProductEntity
            {
                Id = 2,
                Name = "Punjabi",
                Category = Category.Clothing,
                Price = 1500.00M,
                Quantity = 10,
                CreatedAt = new DateTime(2025, 6, 22, 0 , 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 6, 22, 0 , 0, 0, DateTimeKind.Utc),
            });
    }
}