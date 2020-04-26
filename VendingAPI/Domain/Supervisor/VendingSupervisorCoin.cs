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
        public async Task<CoinApiModel> AddCoin(CoinApiModel newCoin)
        {
            Coin coin = newCoin.Convert();

            coin = await _coinRepository.AddAsync(coin);
            newCoin.Id = coin.Id;

            return _mapper.Map<CoinApiModel>(newCoin);
        }

        public async Task<IEnumerable<CoinApiModel>> GetAllCoins()
        {
            var coins = await _coinRepository.GetAllAsync();
            return coins.ConvertAll();
        }

        public async Task<CoinApiModel> GetCoinById(int id)
        {
            Coin coin = await _coinRepository.GetByIdAsync(id);

            return coin.Convert();
        }

        public async Task<bool> UpdateCoin(CoinApiModel updatedCoin)
        {
            Coin coin = await _coinRepository.GetByIdAsync(updatedCoin.Id);
            if (coin is null) return false;
            coin.Value = updatedCoin.Value;
            coin.Quantity = updatedCoin.Quantity;

            return await _coinRepository.UpdateAsync(coin);
        }

        public async Task<bool> DeleteCoin(int id)
        {
            return await _coinRepository.DeleteAsync(id);
        }
    }
}
