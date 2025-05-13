using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Parcial.Aplication.DTOs;
using Parcial.Aplication.Validations;
using Parcial.Domain.Repositories;

namespace Parcial.Aplication.UseCases.Product.Commands.DeleteProduct
{
    public class DeletedProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly idValidator _idvalidator;
        public DeletedProductHandler(IProductRepository repository, IMapper mapper, idValidator validation)
        {
            _repository = repository;
            _mapper = mapper;
            _idvalidator = validation;
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var validation = _idvalidator.Validate(request.Id);
            if (!validation.IsValid)
            {
                var errores = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException($"Producto no válido: {errores}");
            }
            var productExist = await _idvalidator.BeAValidId(request.Id);
            if (!productExist)
            {
                throw new ArgumentException($"No existe producto con el id: {request.Id}");
            }

            var productoEliminado = await _repository.DeleteAsync(request.Id);

            var productoDto = _mapper.Map<ProductDTO>(productoEliminado);

            return new DeleteProductResponse(true, "Producto eliminado", productoDto);
        }
    }

}
