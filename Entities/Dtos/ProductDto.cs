using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }

        [Required(ErrorMessage = "Product name is required.")]
        public String? ProductName { get; init; } = String.Empty;

        public String? Summary { get; init; } = String.Empty;
        
        public String? ImageUrl { get; set; }
        
        [Required(ErrorMessage = "Product price is required.")]
        public decimal Price { get; init; }
        public int? CategoryId { get; init; }
    }
}