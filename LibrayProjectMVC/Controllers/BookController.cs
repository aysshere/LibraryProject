using Entity.Interfaces;
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
    }
}
