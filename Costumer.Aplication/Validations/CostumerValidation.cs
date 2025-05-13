using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Costumer.Aplication.Validations
{
    public class CostumerValidation : AbstractValidator<Costumer.Domain.Entities.CostumerEntity>
    {
        public CostumerValidation()
        {
            RuleFor(costumer => costumer.Name)
                .NotEmpty()
                .WithMessage("El nombre del cliente es requerido")
                .Length(2, 50)
                .WithMessage("El nombre del cliente debe tener entre 3 y 50 caracteres");
            RuleFor(costumer => costumer.LastName)
                .NotEmpty()
                .WithMessage("El apellido del cliente es requerido")
                .Length(2, 50)
                .WithMessage("El apellido del cliente debe tener entre 3 y 50 caracteres");
            //RuleFor(costumer => costumer.Id)
            //    .NotEmpty()
            //    .WithMessage("El Id del cliente es requerido");
            RuleFor(costumer => costumer.Email)
                .NotEmpty()
                .WithMessage("El email del cliente es requerido")
                .EmailAddress()
                .WithMessage("El email del cliente no es valido");

        }
    }
}
