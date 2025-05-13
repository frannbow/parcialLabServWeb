using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Costumer.Aplication.Validations;
using Costumer.Domain.Repositories;
using Costumer.Aplication.DTO;


namespace Costumer.Aplication.UseCases.Costumer.Commands.DeleteCostumer
{
    public class DeleteCostumerHandler : IRequestHandler<DeleteCostumerCommand, DeleteCostumerResponse>
    {
        private readonly iCostumerRepository _repository;
        private readonly IMapper _mapper;
        private readonly idValidator _idvalidator;
        public DeleteCostumerHandler(iCostumerRepository repository, IMapper mapper, idValidator validation) 
        {
            _repository = repository;
            _mapper = mapper;
            _idvalidator = validation;
        }
        public async Task<DeleteCostumerResponse> Handle(DeleteCostumerCommand request, CancellationToken cancellationToken)
        {
            var validation = _idvalidator.Validate(request.Id);
            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Cliente no válido: {errores}");
            }
            var costumerExist = await _idvalidator.BeAValidId(request.Id);
            if (!costumerExist)
            {
                throw new ArgumentException($"No existe cliente con el id: {request.Id}");
            }

            var costumerEliminado = await _repository.DeleteAsync(request.Id);

            var costumerDto = _mapper.Map<CostumerEntityDTO>(costumerEliminado);

            return new DeleteCostumerResponse(true, "Cliente eliminado", costumerDto);
        }
    }
}
