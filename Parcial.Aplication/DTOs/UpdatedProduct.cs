using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.Aplication.DTOs
{
    public class UpdatedProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
    }
}
