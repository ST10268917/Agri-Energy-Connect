using Agri_Energy_Connect.Models;

namespace Agri_Energy_Connect.Factories
{
    public static class ProductFactory
    {
        public static Product Create(string name, string description, decimal price, int quantity, bool available, string categoryName, DateTime productionDate, string imageUrl, string farmerId)
        {
            return new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                Availability = available,
                Category = new Category { Name = categoryName },
                ProductionDate = productionDate,
                ImageUrl = imageUrl,
                FarmerId = farmerId
            };
        }
    }

}
