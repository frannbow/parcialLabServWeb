using Microsoft.EntityFrameworkCore;

using Parcial.Domain.Entities;

namespace Parcial.Infrastructure.DataBase
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet <Product> Products { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
