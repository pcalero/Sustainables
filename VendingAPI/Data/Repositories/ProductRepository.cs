using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendingAPI.Domain.Repositories;
using VendingAPI.Domain.Entities;

namespace VendingAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly VendingContext _vendingContext;

        public ProductRepository(VendingContext vendingContext)
        {
            _vendingContext = vendingContext;
        }

        private async Task<bool> ProductExists(int id) 
        {
            return await _vendingContext.Products.AnyAsync(a => a.Id == id);
        }

        public async Task<Product> AddAsync(Product newProduct)
        {
            await _vendingContext.Products.AddAsync(newProduct);
            await _vendingContext.SaveChangesAsync();

            return newProduct;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            
            return await _vendingContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _vendingContext.Products.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Product updatedProduct)
        {
            if (!await ProductExists(updatedProduct.Id))
                return false;

            _vendingContext.Products.Update(updatedProduct);
            await _vendingContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await ProductExists(id))
                return false;
            var toRemove = _vendingContext.Products.Find(id);
            _vendingContext.Products.Remove(toRemove);
            await _vendingContext.SaveChangesAsync();
            return true;
        }
    }

    
}
