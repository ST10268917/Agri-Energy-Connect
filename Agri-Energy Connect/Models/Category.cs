using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation
        public ICollection<Product> Products { get; set; }
    }
}
