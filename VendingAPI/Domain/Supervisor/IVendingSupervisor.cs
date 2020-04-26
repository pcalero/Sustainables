using System.Collections.Generic;
using System.Threading.Tasks;
using VendingAPI.Domain.ApiModels;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Domain.Supervisor
{
    public interface IVendingSupervisor
    {
        Task<ProductApiModel> AddProduct(ProductApiModel newProduct);
        Task<IEnumerable<ProductApiModel>> GetAllProducts();
        Task<ProductApiModel> GetProductById(int id);
        Task<bool> UpdateProduct(ProductApiModel updatedProduct);
        Task<bool> DeleteProduct(int id);
        Task<ServiceResponse<List<CoinApiModel>>> BuyProduct(int selectedProductId, List<CoinApiModel> userCoins);

        Task<CoinApiModel> AddCoin(CoinApiModel newCoin);
        Task<IEnumerable<CoinApiModel>> GetAllCoins();
        Task<CoinApiModel> GetCoinById(int id);
        Task<bool> UpdateCoin(CoinApiModel updatedCoin);
        Task<bool> DeleteCoin(int id);



    }
}
