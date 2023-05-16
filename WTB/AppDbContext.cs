namespace WTB;
using Microsoft.EntityFrameworkCore;
using WTB.Models;


public class AppDbContext : DbContext
{
    public DbSet<User> UserCredentials { get; set; }
    public DbSet<StreamingServices> StreamingServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the connection string for your database
        optionsBuilder.UseSqlServer("YourConnectionStringHere");
    }
}