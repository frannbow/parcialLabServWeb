using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial.Aplication.DTOs;
using Parcial.Domain.Entities;

namespace Parcial.Aplication.UseCases.Product.Commands.DeleteProduct
{
    public class DeleteProductResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ProductDTO Product { get; set; }
        public DeleteProductResponse(bool success, string message, ProductDTO product)
        {
            Success = success;
            Message = message;
            Product = product;
        }
    }
}
