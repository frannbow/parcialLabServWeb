using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Parcial.Aplication.DTOs;
using Parcial.Aplication.Validations;
using Parcial.Domain.Entities;
using Parcial.Domain.Repositories;

namespace Parcial.Aplication.Services
{
    public class ProductServices : iProductServices
    {

        private readonly IProductRepository _repository;
        private readonly ProductValidator _validations;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepository repository,ProductValidator validations,IMapper mapper)
        {
            _repository = repository; 
            _validations = validations;
            _mapper = mapper;
        }


        public async Task<ProductDTO> PostProduct(ProductDTO product)
        {
            //var ProductEntity = new Product()
            //{
            //    Id = product.Id,    
            //    Name = product.Name,
            //    Price = product.Price,
            //    Description = product.Description,
            //};

            var ProductEntity = _mapper.Map<Product>(product);




            var productvalidator = _validations.Validate(ProductEntity);
            if (!productvalidator.IsValid)
            {
                var errores = string.Join(" | ", productvalidator.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Producto no válido: {errores}");
            }
            await _repository.AddAsync(ProductEntity);
            return product;
        }
        public Task<Product> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDTO>> ListAsync()
        {
           
            var products = await _repository.ListAsync();
            
            var results = _mapper.Map<List<ProductDTO>>(products);

            return results;

        }

        public Task<Product> UpdateAsync(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }   
}
