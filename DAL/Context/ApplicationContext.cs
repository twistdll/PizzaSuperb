using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<PizzaType> PizzaTypes { get; set; } = null!;
        public DbSet<Dopping> Doppings { get; set; } = null!;
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
    }
}
