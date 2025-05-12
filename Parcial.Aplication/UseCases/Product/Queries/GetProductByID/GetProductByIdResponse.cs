using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Parcial.Aplication.DTOs;

namespace Parcial.Aplication.UseCases.Product.Queries.GetProductByID
{
    public class GetProductByIdResponse
    {
        public ProductDTO Products { get; set; }
    }
}
