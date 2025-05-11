using Parcial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Parcial.Infrastructure.DataBase;
using Parcial.Domain.Repositories;

namespace Parcial.Infrastructure.Repositories
{
    public class CostumerRepository : iCostumerRepository
    {
        private readonly AppDBContext _context;
        public CostumerRepository(AppDBContext context)
        {
            _context = context;
        }
        public Task AddAsync(Costumer costumer)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Costumer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<Costumer>> ListAsync()
        {
            throw new NotImplementedException();
        }
        public Task updateAsync(Costumer costumer)
        {
            throw new NotImplementedException();
        }
    }
    

    
}
