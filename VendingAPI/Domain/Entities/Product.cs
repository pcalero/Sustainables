using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingAPI.Domain.ApiModels;
using VendingAPI.Domain.Converters;

namespace VendingAPI.Domain.Entities
{
	public class Product : IConvertModel<Product, ProductApiModel>
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public int Price { get; set; }
		
		public int Quantity { get; set; }

		public ProductApiModel Convert() => new ProductApiModel
		{
			Id = Id,
			Name = Name,
			Price = Price,
			Quantity = Quantity
		};
	}
}
