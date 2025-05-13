using Costumer.Domain.Entities;

namespace Costumer.Domain.Repositories
{
    public interface iCostumerRepository
    {


        Task AddAsync(CostumerEntity costumer);

        Task<CostumerEntity> GetAsync(int id);

        Task<CostumerEntity> updateAsync(int id, CostumerEntity costumer);

        Task<CostumerEntity> DeleteAsync(int id);

        Task<List<CostumerEntity>> ListAsync();



    }
}
