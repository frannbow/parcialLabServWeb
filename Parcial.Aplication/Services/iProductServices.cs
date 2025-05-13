using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial.Domain.Entities;
using Parcial.Aplication.DTOs;

namespace Parcial.Aplication.Services
{
    public interface iProductServices
    {
        Task<List<ProductDTO>> ListAsync();
        Task<Product> GetByIdAsync(int id);
        Task<ProductDTO> PostProduct(ProductDTO product);
        Task<Product> UpdateAsync(int id,Product product);
        Task DeleteAsync(int id);
    }
    
}
