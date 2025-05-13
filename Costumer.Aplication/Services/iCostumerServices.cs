using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Costumer.Aplication.DTO;
using Costumer.Domain.Entities;

namespace Costumer.Aplication.Services
{
    public interface iCostumerServices
    {
        Task<List<CostumerEntityDTO>> ListAsync();
        Task<CostumerEntity> GetByIdAsync(int id);
        Task<CostumerEntityDTO> PostCostumers(CostumerEntityDTO costumer);
        Task<CostumerEntity> UpdateAsync(int id, CostumerEntity costumer);
        Task DeleteAsync(int id);
    }
}
