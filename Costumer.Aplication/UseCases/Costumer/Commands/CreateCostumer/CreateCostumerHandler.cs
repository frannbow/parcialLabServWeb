using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Costumer.Aplication.DTO;
using Costumer.Aplication.Validations;
using Costumer.Domain.Entities;
using Costumer.Domain.Repositories;
using MediatR;

namespace Costumer.Aplication.UseCases.Costumer.Commands.CreateCostumer
{

        public class CreateCostumerHandler : IRequestHandler<CreateCostumerCommand, CreateCostumerResponse>
        {
            private readonly iCostumerRepository _repository;
            private readonly IMapper _mapper;
            private readonly CostumerValidation _validations;
            public CreateCostumerHandler(iCostumerRepository repository, IMapper mapper, CostumerValidation validations)
            {
                _repository = repository;
                _mapper = mapper;
                _validations = validations;
            }
            public async Task<CreateCostumerResponse> Handle(CreateCostumerCommand request, CancellationToken cancellationToken)
            {
                {
                    var costumer = new CostumerEntity()
                    {
                        Name = request.Name,
                        LastName = request.LastName,
                        Email = request.Email,
                    };



                    var costumervalidator = _validations.Validate(costumer);
                    if (!costumervalidator.IsValid)
                    {
                        var errores = string.Join(" | ", costumervalidator.Errors.Select(x => x.ErrorMessage));
                        throw new ArgumentException($"Cliente no válido: {errores}");
                    }
                    await _repository.AddAsync(costumer);
                    return new CreateCostumerResponse()
                    {
                        Costumer = _mapper.Map<CostumerEntityDTO>(costumer)
                    };
                }

            }

        }
    }

