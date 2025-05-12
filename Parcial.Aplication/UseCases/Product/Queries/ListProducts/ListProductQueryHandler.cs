using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Parcial.Aplication.DTOs;
using Parcial.Domain.Repositories;

namespace Parcial.Aplication.UseCases.Product.Queries.ListProducts
{
    public class ListProductQueryHandler : IRequestHandler<ListProductsQuery,ListProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ListProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }
        public async Task<ListProductsResponse> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListAsync();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products);
            return new ListProductsResponse 
            {
                Products = productsDTO 
            };
        }
    }

}
