using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Parcial.Aplication.DTOs;
using Parcial.Aplication.Validations;
using Parcial.Domain.Entities;
using Parcial.Domain.Repositories;

namespace Parcial.Aplication.UseCases.Product.Queries.GetProductByID
{
    public class GetProductByIDHandler : IRequestHandler<GetProductByIDQuery, GetProductByIdResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly idValidator _idvalidator;
        private readonly IMapper _mapper;
        public GetProductByIDHandler(IProductRepository repository, IMapper mapper, idValidator idvalidator)
        {
            _productRepository = repository;
            _mapper = mapper;
            _idvalidator = idvalidator;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            int productId = request.Id;
            var validation = _idvalidator.Validate(productId);
            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Id no válido: {errores}");
            }
            var result = await _productRepository.GetAsync(productId);
            var productDTO = _mapper.Map<ProductDTO>(result);
            return new GetProductByIdResponse
            {
                Products = productDTO
            };
        }
    }

}
