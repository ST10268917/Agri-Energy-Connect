
using Agri_Energy_Connect.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models.ViewModels
{
    public class ProductFilterViewModel
    {
        public string SelectedFarmerId { get; set; }
        public string CategoryName { get; set; }  
        public string Search { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public List<ApplicationUser> Farmers { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> FilteredProducts { get; set; }
    }
}