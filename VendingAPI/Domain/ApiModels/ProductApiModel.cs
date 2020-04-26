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
    public class ProductApiModel : IConvertModel<ProductApiModel, Product>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Price { get; set; }
        
        public int Quantity { get; set; }

        public Product Convert() => new Product
        {
            Id = Id,
            Name = Name,
            Price = Price,
            Quantity = Quantity,

        };
    }
}
