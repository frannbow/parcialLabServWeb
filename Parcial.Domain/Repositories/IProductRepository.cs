using Parcial.Domain.Entities;

namespace Parcial.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task<Product> GetAsync(int id);

        Task updateAsync (Product product);

        Task DeleteAsync(int id);

        Task<List<Product>> ListAsync();   

    }
}
