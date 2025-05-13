using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Costumer.Domain.Repositories;

namespace Costumer.Aplication.Validations
{
    public class idValidator : AbstractValidator<int>
    {
        private readonly iCostumerRepository _repository;
        public idValidator(iCostumerRepository productRepository)
        {
            _repository = productRepository;
        }
        public idValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("El id no puede estar vacío")
                .GreaterThan(0).WithMessage("El id debe ser mayor que 0");

        }
        public async Task<bool> BeAValidId(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product == null)
            {
                return false;
            }
            return true;
        }
    }
}
