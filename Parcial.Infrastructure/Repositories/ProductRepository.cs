
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

        public async Task<Product> GetAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<List<Product>> ListAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<Product> updateAsync(int id, Product product)
        {
            var realProduct = await _context.Products.FindAsync(id);
            if (realProduct == null)
            {
                throw new KeyNotFoundException($"Producto con ID {id} no encontrado.");
            }

            realProduct.Name = product.Name;
            realProduct.Price = product.Price;
            realProduct.Description = product.Description;
            realProduct.isDeleted = product.isDeleted;
            await _context.SaveChangesAsync();
            return realProduct;
        }
    }
}
