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
        private readonly idValidator _idvalidator;
        private readonly IMapper _mapper;
        private readonly iWeatherServices _weatherServices;

        public ProductServices(IProductRepository repository,ProductValidator validations,IMapper mapper, iWeatherServices weatherServices, idValidator idvalidator)
        {
            _repository = repository; 
            _validations = validations;
            _idvalidator = idvalidator;
            _mapper = mapper;
            _weatherServices = weatherServices;
        }

        public async Task<ProductDTO> PostProduct(ProductDTO product)
        {
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

        public async Task<Product> GetByIdAsync(int id)
        {
            int productId = id;
            var validation = _idvalidator.Validate(productId);
            if(!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Id no válido: {errores}");
            }
            var result = await _repository.GetAsync(productId);
            return result;
        }

        public async Task<List<ProductDTO>> ListAsync()
        {
           
            var products = await _repository.ListAsync();

            //var weather = await _weatherServices.GetAllWeatherInfo();    
            
            var results = _mapper.Map<List<ProductDTO>>(products);

            return results;

        }

        public async Task<Product> UpdateAsync(int id,Product product)
        {
            var updatedProduct = _mapper.Map<Product>(product);
            var productId = id;
            var productvalidator = _validations.Validate(updatedProduct);
            var validation = _idvalidator.Validate(productId);

            if (!productvalidator.IsValid)
            {
                var errores = string.Join(" | ", productvalidator.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Producto no válido: {errores}");
            }
           
            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Id no válido: {errores}");
            }
            var result = await _repository.updateAsync(id,updatedProduct);
            return result;

        }
    }   
}
