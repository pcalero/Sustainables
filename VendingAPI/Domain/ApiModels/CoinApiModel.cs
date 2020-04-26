using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VendingAPI.Domain.Converters;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Domain.ApiModels
{
    public class CoinApiModel : IConvertModel<CoinApiModel, Coin>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int Value { get; set; }
        
        public int Quantity { get; set; }

        public Coin Convert() => new Coin
        {
            Id = Id,
            Value = Value,
            Quantity = Quantity,

        };
    }
}
