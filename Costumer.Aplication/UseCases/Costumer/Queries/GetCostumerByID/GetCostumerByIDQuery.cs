using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Costumer.Aplication.UseCases.Costumer.Queries.GetCostumerByID
{
    public class GetCostumerByIDQuery : IRequest<GetCostumerByIdResponse>
    {
        public int Id { get; set; }
        public GetCostumerByIDQuery(int productId)
        {
            Id = productId;
        }
    }
}
