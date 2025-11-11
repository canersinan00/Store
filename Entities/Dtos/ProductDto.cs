using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
    public int ProductId { get; init; }
    [Required(ErrorMessage = "Product name is rquired.")]
    public String? ProductName { get; init; } = String.Empty;
    [Required(ErrorMessage = "Product price is rquired.")]
    public decimal Price { get; init; }
    
    public int? CategoryId { get; init; }
    }
}