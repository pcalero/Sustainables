using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingAPI.Domain.ApiModels;
using VendingAPI.Domain.Extensions;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Domain.Supervisor
{
    public partial class VendingSupervisor
    {
        public async Task<ProductApiModel> AddProduct(ProductApiModel newProduct)
        {
            Product product = newProduct.Convert();

            product = await _productRepository.AddAsync(product);
            newProduct.Id = product.Id;

            return newProduct;
        }

        public async Task<IEnumerable<ProductApiModel>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return products.ConvertAll();
        }

        public async Task<ProductApiModel> GetProductById(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            return product.Convert();
        }

        public async Task<bool> UpdateProduct(ProductApiModel updatedProduct)
        {
            Product product = await _productRepository.GetByIdAsync(updatedProduct.Id);
            if (product is null) return false;
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<ServiceResponse<List<CoinApiModel>>> BuyProduct(int selectedProductId, List<CoinApiModel> userCoins) {
            ServiceResponse<List<CoinApiModel>> serviceResponse = new ServiceResponse<List<CoinApiModel>>();

            // check if productSelected exists
            ProductApiModel foundProduct = await GetProductById(selectedProductId);
            if (foundProduct == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found";
                serviceResponse.Data = userCoins;
                return serviceResponse;
            }

            // check if productSelected is in stock
            if (foundProduct.Quantity == 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No stock of selected product";
                serviceResponse.Data = userCoins;
                return serviceResponse;
            }

            // check if userCoins is enough
            var totalAmountInserted = 0;
            userCoins.ForEach(c => {
                totalAmountInserted = totalAmountInserted + c.Quantity * c.Value;
            });
            if (totalAmountInserted < foundProduct.Price)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Insufficient amount";
                serviceResponse.Data = userCoins;
                return serviceResponse;
            }
            // check if there are enough coins to return the change
            var currentCoins = (await GetAllCoins()).OrderByDescending(c => c.Value).ToList();
            List<CoinApiModel> coinsToReturn = CoinExtensions.CalculateBestCoinBack(currentCoins, totalAmountInserted - foundProduct.Price);

            bool areEnoughCoins = true;
            if (coinsToReturn != null)
            {
                coinsToReturn.ForEach(async c => {
                    var coinToUpdate = await GetCoinById(c.Id);
                    if (coinToUpdate.Quantity < c.Quantity)
                    {
                        areEnoughCoins = false;
                    }
                });
            }

            if (coinsToReturn == null || !areEnoughCoins) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There is no enough change";
                serviceResponse.Data = userCoins;
                return serviceResponse;
            }

            foundProduct.Quantity = foundProduct.Quantity - 1;
            await UpdateProduct(foundProduct);

            foreach (var c in coinsToReturn) {
                var coinToUpdate = await GetCoinById(c.Id);
                coinToUpdate.Quantity = coinToUpdate.Quantity - c.Quantity;
                await UpdateCoin(coinToUpdate);
            };

            serviceResponse.Message = "Get your product";
            serviceResponse.Data = coinsToReturn;

            return serviceResponse;
        }

        

        
    }
}
