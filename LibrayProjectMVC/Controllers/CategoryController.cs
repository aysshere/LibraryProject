using Entity.Interfaces;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace LibrayProjectMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryViewModel> _logger;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryViewModel> logger)
        {

            _categoryService = categoryService;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _categoryService.AddCategoryAsync(model);
                TempData["Message"] = result;
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
