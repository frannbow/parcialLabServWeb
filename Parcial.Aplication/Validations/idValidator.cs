using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Parcial.Domain.Repositories;

namespace Parcial.Aplication.Validations
{
    public class idValidator : AbstractValidator<int>
    {
        private readonly IProductRepository _productRepository;
        public idValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public idValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("El id no puede estar vacío")
                .GreaterThan(0).WithMessage("El id debe ser mayor que 0");

        }
        public async Task<bool> BeAValidId(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return false;
            }
            return true;
        }
    }
}
