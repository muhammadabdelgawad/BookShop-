using Data_Access.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace BookShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult GetAllCategories()
        {
            var categories = _dbContext.Categories.ToList();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
               
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("GetAllCategories");
            }
            return View(category);
        }
       


    }
}
