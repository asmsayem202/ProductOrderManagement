using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.Enums;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Variant> Variants => Set<Variant>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Variant)
            .WithMany()
            .HasForeignKey(oi => oi.VariantId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Classic Mug", Brand = "MugBrand", Type = ProductType.Mug },
            new Product { Id = 2, Name = "Eco Jug", Brand = "JugPro", Type = ProductType.Jug },
            new Product { Id = 3, Name = "Coffee Cup", Brand = "CupX", Type = ProductType.Cup }
        );

        // Seed Variants
        modelBuilder.Entity<Variant>().HasData(
            new Variant { Id = 1, ProductId = 1, Color = "White", Specification = "Ceramic", Size = Size.Medium },
            new Variant { Id = 2, ProductId = 1, Color = "Black", Specification = "Steel", Size = Size.Large },
            new Variant { Id = 3, ProductId = 2, Color = "Blue", Specification = "Plastic", Size = Size.Large },
            new Variant { Id = 4, ProductId = 3, Color = "Red", Specification = "Glass", Size = Size.Small }
        );
    }

}
