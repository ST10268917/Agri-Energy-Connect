using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class AddProductViewModel
{
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 100000, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    [Display(Name = "Available?")]
    public bool Availability { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters")]
    public string CategoryName { get; set; }

    [Required(ErrorMessage = "Production date is required")]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }

    [Required(ErrorMessage = "Product image is required")]
    public IFormFile Image { get; set; }
}
