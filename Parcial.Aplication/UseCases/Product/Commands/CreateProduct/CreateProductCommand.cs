using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Parcial.Aplication.UseCases.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        
    }
}
