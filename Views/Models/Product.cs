using System.ComponentModel.DataAnnotations;

namespace Views.Models;

public class Product
{
    [Required(ErrorMessage = "Name your product")]
    public string Name { get; set; }

    [Required]
    [Range(0.1, 100_000)]
    public decimal Price { get; set; }
}