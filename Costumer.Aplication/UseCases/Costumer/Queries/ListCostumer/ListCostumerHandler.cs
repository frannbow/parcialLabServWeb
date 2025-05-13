using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Costumer.Aplication.DTO;
using Costumer.Domain.Repositories;
using MediatR;

namespace Costumer.Aplication.UseCases.Costumer.Queries.ListCostumer
{
    public class ListCostumerHandler : IRequestHandler<ListCostumerQuery, ListCostumerResponse>
    {
        private readonly iCostumerRepository _productRepository;
        private readonly IMapper _mapper;
        public ListCostumerHandler(iCostumerRepository repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }
        public async Task<ListCostumerResponse> Handle(ListCostumerQuery request, CancellationToken cancellationToken)
        {
            var costumers = await _productRepository.ListAsync();
            var costumerDTO = _mapper.Map<List<CostumerEntityDTO>>(costumers);
            return new ListCostumerResponse
            {
                Costumers = costumerDTO
            };
        }
    }
}
