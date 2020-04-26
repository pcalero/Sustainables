using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendingAPI.Domain.Repositories;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Data.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        private readonly VendingContext _vendingContext;

        public CoinRepository(VendingContext vendingContext)
        {
            _vendingContext = vendingContext;
        }

        private async Task<bool> CoinExists(int id)
        {
            return await _vendingContext.Coins.AnyAsync(a => a.Id == id);
        }

        public async Task<Coin> AddAsync(Coin newCoin)
        {
            await _vendingContext.Coins.AddAsync(newCoin);
            await _vendingContext.SaveChangesAsync();

            return newCoin;
        }

        public async Task<IEnumerable<Coin>> GetAllAsync()
        {

            return await _vendingContext.Coins.ToListAsync();
        }

        public async Task<Coin> GetByIdAsync(int id)
        {
            return await _vendingContext.Coins.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Coin updatedCoin)
        {
            if (!await CoinExists(updatedCoin.Id))
                return false;

            _vendingContext.Coins.Update(updatedCoin);
            await _vendingContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await CoinExists(id))
                return false;
            var toRemove = _vendingContext.Coins.Find(id);
            _vendingContext.Coins.Remove(toRemove);
            await _vendingContext.SaveChangesAsync();
            return true;
        }
    }


}
