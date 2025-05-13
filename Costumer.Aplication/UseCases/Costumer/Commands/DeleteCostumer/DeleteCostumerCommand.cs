using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Costumer.Aplication.UseCases.Costumer.Commands.DeleteCostumer
{
    public class DeleteCostumerCommand : IRequest<DeleteCostumerResponse>
    {
        public int Id { get; set; }
        public DeleteCostumerCommand(int id)
        {
            Id = id;
        }
    }
}
