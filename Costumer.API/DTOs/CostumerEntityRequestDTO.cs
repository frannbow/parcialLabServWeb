using System.ComponentModel.DataAnnotations;

namespace Costumer.API.DTOs
{
    public class CostumerEntityRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
