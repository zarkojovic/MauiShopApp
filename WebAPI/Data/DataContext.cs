using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;

namespace WebAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Seeder(ref modelBuilder);
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    private static void Seeder(ref ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(Role.GetInitialRoles());
        modelBuilder.Entity<User>().HasData(User.GetInitalUsers());
        modelBuilder.Entity<Category>().HasData(Category.GetInitialData());
        modelBuilder.Entity<Offer>().HasData(Offer.GetInitialData());
        modelBuilder.Entity<Product>().HasData(Product.GetInitialData());
    }
}