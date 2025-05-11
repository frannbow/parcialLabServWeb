using Parcial.Domain.Entities;

namespace Parcial.Domain.Repositories
{
    public interface iCostumerRepository
    {
       
            Task AddAsync(Costumer costumer);

            Task<Costumer> GetAsync(int id);

            Task updateAsync(Costumer costumer);

            Task DeleteAsync(int id);

            Task<List<Costumer>> ListAsync();

        
    }
}
