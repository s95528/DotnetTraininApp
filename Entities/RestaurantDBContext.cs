using Microsoft.EntityFrameworkCore;

namespace DotnetApp.Entities;

public class RestaurantDbContext : DbContext
{
    private string _connectionString =
        "Host=localhost;Database=restaurants;Username=postgres;Password=qwer1234";
    //private MySqlServerVersion _serverVersion = new MySqlServerVersion(new Version(8, 0, 3));
    
    public DbSet<Restauant> Restauants { get; set; }
    
    public DbSet<Address> Addresses { get; set; }
    
    public DbSet<Dish> Dishes { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restauant>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(r =>
                r.Name).IsRequired().HasMaxLength(25);
        });
        modelBuilder.Entity<Address>().Property(a => a.City).HasMaxLength(50);
        modelBuilder.Entity<Address>().Property(a => a.Street).HasMaxLength(50);
        modelBuilder.Entity<Dish>().Property(d => d.Name).IsRequired();
    }
}