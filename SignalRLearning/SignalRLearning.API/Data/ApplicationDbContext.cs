using Microsoft.EntityFrameworkCore;
using SignalRLearning.API.Models;

namespace SignalRLearning.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }

    // Başlangıç için dummy data ekleyelim
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 25000 },
            new Product { Id = 2, Name = "Mouse", Price = 500 }
        );
    }
}
