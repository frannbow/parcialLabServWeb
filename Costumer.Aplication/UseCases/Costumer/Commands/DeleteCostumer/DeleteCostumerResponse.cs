using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Costumer.Aplication.DTO;

namespace Costumer.Aplication.UseCases.Costumer.Commands.DeleteCostumer
{
    public class DeleteCostumerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public CostumerEntityDTO Costumer { get; set; }
        public DeleteCostumerResponse(bool success, string message, CostumerEntityDTO costumer)
        {
            Success = success;
            Message = message;
            Costumer = costumer;
        }
    }
}
