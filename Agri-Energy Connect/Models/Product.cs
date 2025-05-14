using Agri_Energy_Connect.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool Availability { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public string ImageUrl { get; set; }

        // Foreign Keys
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string FarmerId { get; set; }  // FK to AspNetUsers
        public ApplicationUser Farmer { get; set; }
    }
}
