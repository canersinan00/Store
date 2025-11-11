using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Product name is rquired.")]
    public String? ProductName { get; set; } = String.Empty;
    [Required(ErrorMessage = "Product price is rquired.")]
    public decimal Price { get; set; }
    
    public int? CategoryId { get; set; }    // Foreign Key
    public Category? Category { get; set; } //Navigation property

}
