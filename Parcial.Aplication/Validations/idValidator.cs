using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Parcial.Aplication.Validations
{
    public class idValidator : AbstractValidator<int>
    {
        public idValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("El id no puede estar vacío")
                .GreaterThan(0).WithMessage("El id debe ser mayor que 0");
        }
    }
}
