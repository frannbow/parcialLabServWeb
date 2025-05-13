using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Costumer.Aplication.UseCases.Costumer.Commands.CreateCostumer
{
    public class CreateCostumerCommand : IRequest<CreateCostumerResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    
    }
}
