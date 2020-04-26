using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Data.Configurations
{
    public class CoinConfiguration
    {
        public CoinConfiguration(EntityTypeBuilder<Coin> entity)
        {

            entity.Property(e => e.Value)
                .IsRequired();

            entity.Property(e => e.Quantity)
                .IsRequired();

            entity.HasData(
                new Coin
                {
                    Id = 1,
                    Value = 10,
                    Quantity = 100,
                },
                new Coin
                {
                    Id = 2,
                    Value = 20,
                    Quantity = 100,
                },
                new Coin
                {
                    Id = 3,
                    Value = 50,
                    Quantity = 100,
                },
                new Coin
                {
                    Id = 4,
                    Value = 100,
                    Quantity = 100,
                }
            );
        }
    }
}
