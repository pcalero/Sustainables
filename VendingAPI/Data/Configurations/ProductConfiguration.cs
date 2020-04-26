using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Data.Configurations
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entity)
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(160);

            entity.Property(e => e.Price)
                .IsRequired();

            entity.Property(e => e.Quantity)
                .IsRequired();

            entity.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Tea",
                    Price = 130,
                    Quantity = 20,
                },
                new Product
                {
                    Id = 2,
                    Name = "Expresso",
                    Price = 180,
                    Quantity = 20,
                },
                new Product
                {
                    Id = 3,
                    Name = "Juice",
                    Price = 180,
                    Quantity = 20,
                },
                new Product
                {
                    Id = 4,
                    Name = "Chicken soup",
                    Price = 180,
                    Quantity = 15,
                }
            );
        }
    }
}
