using System.Collections.Generic;
using System.Threading.Tasks;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product newProduct);
        Task<bool> UpdateAsync(Product updatedProduct);
        Task<bool> DeleteAsync(int id);
    }
}
