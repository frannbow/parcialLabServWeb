using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Costumer.Domain.Entities;
using Costumer.Domain.Repositories;
using Costumer.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Costumer.Infrastructure.Repositories
{
    public class CostumerRepository : iCostumerRepository
    {
        private readonly AppDBContext _context;

        public CostumerRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(CostumerEntity costumer)
        {
            var newcostumer = _context.Costumers.AddAsync(costumer);
            await _context.SaveChangesAsync();
        }
        public async Task<CostumerEntity> DeleteAsync(int id)
        {
            var costumer = _context.Costumers.FirstOrDefault(x => x.Id == id);
            if (costumer == null)
            {
                throw new KeyNotFoundException($"no existe cliente con id :{id} ");
            }
            costumer.isDeleted = true;
            await _context.SaveChangesAsync();
            return costumer;
        }
        public async Task<CostumerEntity> GetAsync(int id)
        {
            var costumer = _context.Costumers.FirstOrDefault(x => x.Id == id);
            return costumer;
        }
        public async Task<List<CostumerEntity>> ListAsync()
        {
            var costumers = await _context.Costumers.Where(p => !p.isDeleted)
                    .ToListAsync();
            return costumers ;
        }
        public async Task<CostumerEntity> updateAsync(int id, CostumerEntity costumer)
        {
            var realCostumer = await _context.Costumers.FindAsync(id);
            if (realCostumer == null)
            {
                throw new KeyNotFoundException($"Producto con ID {id} no encontrado.");
            }

            realCostumer.Name = costumer.Name;
            realCostumer.LastName = costumer.LastName;
            realCostumer.Email = costumer.Email;
            realCostumer.isDeleted = costumer.isDeleted;
            await _context.SaveChangesAsync();
            return realCostumer;
        }
    }
}
