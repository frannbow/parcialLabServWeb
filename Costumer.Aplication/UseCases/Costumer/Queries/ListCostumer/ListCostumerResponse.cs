using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Costumer.Aplication.DTO;

namespace Costumer.Aplication.UseCases.Costumer.Queries.ListCostumer
{
    public class ListCostumerResponse
    {
        public List<CostumerEntityDTO> Costumers { get; set; }
    }
}
