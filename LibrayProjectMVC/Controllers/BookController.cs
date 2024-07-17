using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibrayProjectMVC.Controllers
{
    public class BookController : Controller
    {
        IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Books books)
        {
            _bookService.Add(books);
            return View();
        }
    }
}
