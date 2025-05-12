using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Parcial.Aplication.UseCases.Product.Queries.GetProductByID
{
    public class GetProductByIDQuery : IRequest<GetProductByIdResponse>
    {
        public int Id { get; set; }
        public GetProductByIDQuery(int productId)
        {
            Id = productId;
        }
    }
}
