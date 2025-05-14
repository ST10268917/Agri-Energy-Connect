using Agri_Energy_Connect.Areas.Identity.Data;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Agri_Energy_Connect.Data;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect.Factories;
using Agri_Energy_Connect.Services;

[Authorize(Roles = "Farmer")]
public class FarmerController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AuthDbContext _context;
    private readonly IWebHostEnvironment _env;

    public FarmerController(UserManager<ApplicationUser> userManager, AuthDbContext context, IWebHostEnvironment env)
    {
        _userManager = userManager;
        _context = context;
        _env = env;
    }

    public async Task<IActionResult> MyProducts(string search)
    {
        var user = await _userManager.GetUserAsync(User);
        var products = await _context.Products
            .Where(p => p.FarmerId == user.Id &&
                (string.IsNullOrEmpty(search) || p.Name.Contains(search)))
            .Include(p => p.Category)
            .ToListAsync();

        return View(products);
    }


    public IActionResult AddProduct()
    {
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            return View(model);
        }

        string fileName = null;

        if (model.Image != null)
        {
            string uploadDir = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadDir);

            fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
            string filePath = Path.Combine(uploadDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);
            }
        }

        var user = await _userManager.GetUserAsync(User);

        // Check if the category already exists
        var category = _context.Categories.FirstOrDefault(c => c.Name.ToLower() == model.CategoryName.Trim().ToLower());

        if (category == null)
        {
            category = new Category { Name = model.CategoryName.Trim() };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(); // Save to generate CategoryId
        }

        var imageUrl = "/uploads/" + fileName;

        var product = ProductFactory.Create(
            model.Name,
            model.Description,
            model.Price,
            model.Quantity,
            model.Availability,
            model.CategoryName,
            model.ProductionDate,
            imageUrl,
            user.Id
        );

        _context.Products.Add(product);
        AppLogger.Instance.Log($"New product added by user {user.Email}: {model.Name}");
        await _context.SaveChangesAsync();

        return RedirectToAction("MyProducts");
    }
}
