using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Parcial.Aplication.DTOs;
using Parcial.Aplication.Validations;
using Parcial.Domain.Entities;
using Parcial.Domain.Repositories;

namespace Parcial.Aplication.UseCases.Product.Commands.CreateProduct
{
 
        public class createProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
        {
            private readonly IProductRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProductValidator _validations;
            public createProductCommandHandler(IProductRepository repository, IMapper mapper, ProductValidator validations)
            {
                _repository = repository;
                _mapper = mapper;
                _validations = validations;
            }
            public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                {
                    var product = new Parcial.Domain.Entities.Product()
                    {
                        Name = request.Name,
                        Price = request.Price,
                        Description = request.Description,
                    };

                    

                    var productvalidator = _validations.Validate(product);
                    if (!productvalidator.IsValid)
                    {
                        var errores = string.Join(" | ", productvalidator.Errors.Select(x => x.ErrorMessage));
                        throw new ArgumentException($"Producto no válido: {errores}");
                    }
                    await _repository.AddAsync(product);
                    return new CreateProductResponse()
                    {
                        Product = _mapper.Map<ProductDTO>(product)
                    };
                }
           
        }

    }
}
