namespace WTB;
using Microsoft.EntityFrameworkCore;
using WTB.Models;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    public DbSet<User> User { get; set; }
    public DbSet<StreamingServices> StreamingServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the connection string for your database
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=ormtest;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StreamingServices>()
            
            .Property(e => e.Netflix)            
            .HasConversion<byte>();

        modelBuilder.Entity<StreamingServices>()

            .Property(e => e.AmazonPrime)
            .HasConversion<byte>();

        modelBuilder.Entity<StreamingServices>()

            .Property(e => e.DisneyPlus)
            .HasConversion<byte>();

        modelBuilder.Entity<StreamingServices>()

            .Property(e => e.HBO)
            .HasConversion<byte>();
    }
}