using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Costumer.Aplication.DTO;

namespace Costumer.Aplication.UseCases.Costumer.Queries.GetCostumerByID
{
    public class GetCostumerByIdResponse
    {
        public CostumerEntityDTO Costumers { get; set; }
    }
}
