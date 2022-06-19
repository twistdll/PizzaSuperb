using DAL.Entities;
using DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderConfiguration> OrderConfigurations { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Promocode> Promocodes { get; set; } = null!;

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .Property(x => x.ProductType)
                .HasConversion(
                    x => x.ToString(),
                    x => Enum.Parse<ProductType>(x));
        }
    }
}
