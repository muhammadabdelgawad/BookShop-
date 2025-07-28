using System.Threading.Tasks;
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
        
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.Products.GetAllWithCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories =await  _unitOfWork.Categories.GetAllAsync();
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
               await _unitOfWork.Products.AddAsync(product);
               await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _unitOfWork.Categories.GetAllAsync();
            return View(product);
        }


        public async Task <IActionResult> Edit(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            ViewBag.Categories =await _unitOfWork.Categories.GetAllAsync();
            return View(product);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();
                  _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));



        }
    }
}
