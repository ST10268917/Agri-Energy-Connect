using Agri_Energy_Connect.Areas.Identity.Data;
using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AuthDbContext _context;


        public EmployeeController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AuthDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> FarmerList()
        {
            var farmers = await _userManager.GetUsersInRoleAsync("Farmer");
            return View(farmers);
        }

        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFarmer(AddFarmerViewModel model)
        {
            if (ModelState.IsValid)
            {

                var farmer = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(farmer, model.Password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("Farmer"))
                        await _roleManager.CreateAsync(new IdentityRole("Farmer"));

                    await _userManager.AddToRoleAsync(farmer, "Farmer");

                    return RedirectToAction("FarmerList");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine("Model Error: " + error.ErrorMessage);
                }
            }


            return View(model);
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> ProductList(string selectedFarmerId, int? selectedCategoryId, DateTime? startDate, DateTime? endDate, string search)
        {
            var farmers = await _userManager.GetUsersInRoleAsync("Farmer");
            var categories = _context.Categories.ToList();

            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Farmer)
                .AsQueryable();

            if (!string.IsNullOrEmpty(selectedFarmerId))
            {
                products = products.Where(p => p.FarmerId == selectedFarmerId);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }


            if (selectedCategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == selectedCategoryId.Value);
            }

            if (startDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate <= endDate.Value);
            }

            var viewModel = new ProductFilterViewModel
            {
                Farmers = farmers.ToList(),
                Categories = categories,
                FilteredProducts = products.ToList(),
                SelectedFarmerId = selectedFarmerId,
                SelectedCategoryId = selectedCategoryId,
                StartDate = startDate,
                EndDate = endDate,
                Search = search
            };


            return View(viewModel);
        }

    }
}
