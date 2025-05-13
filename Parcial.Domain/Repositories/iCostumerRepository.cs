using Parcial.Domain.Entities;

namespace Parcial.Domain.Repositories
{
    public interface iCostumerRepository
    {
       
            Task AddAsync(Costumer costumer);

            Task<Costumer> GetAsync(int id);

            Task<Costumer>updateAsync(Costumer costumer);

            Task<Costumer>DeleteAsync(int id);

            Task<List<Costumer>> ListAsync();

        
    }
}
