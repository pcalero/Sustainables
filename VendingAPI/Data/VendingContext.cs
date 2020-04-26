using Microsoft.EntityFrameworkCore;
using VendingAPI.Data.Configurations;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Data
{
    public class VendingContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public VendingContext(DbContextOptions<VendingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new CoinConfiguration(modelBuilder.Entity<Coin>());

        }
    }
}
