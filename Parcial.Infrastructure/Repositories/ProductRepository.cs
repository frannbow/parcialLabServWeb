
using Parcial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Parcial.Infrastructure.DataBase;
using Parcial.Domain.Repositories;

namespace Parcial.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context) { 

            _context = context;

        }
        public async Task AddAsync(Product product)
        {
            var newproduct = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> ListAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public Task updateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
