using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingAPI.Domain.ApiModels;
using VendingAPI.Domain.Converters;

namespace VendingAPI.Domain.Entities
{
	public class Coin : IConvertModel<Coin, CoinApiModel>
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int Value { get; set; }

		public int Quantity { get; set; }

		public CoinApiModel Convert() => new CoinApiModel
		{
			Id = Id,
			Value = Value,
			Quantity = Quantity
		};
	}
}
