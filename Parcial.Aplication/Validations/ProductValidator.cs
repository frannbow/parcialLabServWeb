using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Parcial.Domain.Entities;

namespace Parcial.Aplication.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(Product => Product.Name)
                .NotEmpty()
                .WithMessage("El nombre del producto es requerido")
                .Length(2, 50)
                .WithMessage("El nombre del producto debe tener entre 3 y 50 caracteres");
            //RuleFor(Product => Product.Id)
            //    .NotEmpty()
            //    .WithMessage("El Id del producto es requerido");
            RuleFor(Product => Product.Price)
                .NotEmpty()
                .WithMessage("El precio del producto es requerido")
                .GreaterThan(0)
                .WithMessage("El precio del producto debe ser mayor que 0");



        }

        
    }
}
