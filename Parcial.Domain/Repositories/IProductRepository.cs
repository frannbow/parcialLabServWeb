using Parcial.Domain.Entities;

namespace Parcial.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task<Product> GetAsync(int id);

        Task <Product>updateAsync (int id, Product product);

        Task DeleteAsync(int id);

        Task<List<Product>> ListAsync();   

    }
}
