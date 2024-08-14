using Entity.Interfaces;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibrayProjectMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.ImageUrl))
                {
                    model.ImageUrl = "/img/" + model.ImageUrl;
                }
                var result = await _bookService.AddBookAsync(model);
                TempData["Message"] = result;
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
