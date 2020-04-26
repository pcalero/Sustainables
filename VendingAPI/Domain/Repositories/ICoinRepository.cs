using System.Collections.Generic;
using System.Threading.Tasks;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Domain.Repositories
{
    public interface ICoinRepository
    {
        Task<IEnumerable<Coin>> GetAllAsync();
        Task<Coin> GetByIdAsync(int id);
        Task<Coin> AddAsync(Coin newCoin);
        Task<bool> UpdateAsync(Coin updatedCoin);
        Task<bool> DeleteAsync(int id);
    }
}
