using System.ComponentModel.DataAnnotations;

namespace Parcial.API.DTO
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100000000)]
        public decimal Price { get; set; }

        [Required]
        [Length(2,1024)]
        public string Description { get; set; }
    }

}
