using Microsoft.EntityFrameworkCore;

using Costumer.Domain.Entities;

namespace Costumer.Infrastructure.DataBase
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<CostumerEntity> Costumers { get; set; }
    }
}
