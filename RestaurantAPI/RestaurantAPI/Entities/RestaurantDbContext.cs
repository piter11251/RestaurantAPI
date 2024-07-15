using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString = "Data Source=DESKTO-6RCKR67;Initial Catalog=RestaurantDB;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(g => g.Street)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(g => g.City)
                .IsRequired()
                .HasMaxLength(50);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
