using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Costumer.Aplication.DTO;
using Costumer.Aplication.Validations;
using Costumer.Domain.Entities;
using Costumer.Domain.Repositories;

namespace Costumer.Aplication.UseCases.Costumer.Queries.GetCostumerByID
{
    public class GetCostumerByIDHandler : IRequestHandler<GetCostumerByIDQuery, GetCostumerByIdResponse>
    {
        private readonly iCostumerRepository _repository;
        private readonly idValidator _idvalidator;
        private readonly IMapper _mapper;
        public GetCostumerByIDHandler(iCostumerRepository repository, IMapper mapper, idValidator idvalidator)
        {
            _repository = repository;
            _mapper = mapper;
            _idvalidator = idvalidator;
        }

        public async Task<GetCostumerByIdResponse> Handle(GetCostumerByIDQuery request, CancellationToken cancellationToken)
        {
            int productId = request.Id;
            var validation = _idvalidator.Validate(productId);
            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Id no válido: {errores}");
            }
            var result = await _repository.GetAsync(productId);
            var productDTO = _mapper.Map<CostumerEntityDTO>(result);
            return new GetCostumerByIdResponse
            {
                Costumers = productDTO
            };
        }
    }

}
