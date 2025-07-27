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

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();
            return View("GetAllCategories", categories); // Or View("Index") if you create Index.cshtml
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


        public IActionResult Details(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }
        public IActionResult Edit(int id) 
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
