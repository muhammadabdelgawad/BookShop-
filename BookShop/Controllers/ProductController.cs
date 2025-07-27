using Data_Access.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace BookShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            var products = _unitOfWork.Products.GetAllWithCategory();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Add(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            return View(product);
        }
    }
}
