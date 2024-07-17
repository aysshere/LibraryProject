using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjectMVC.Controllers
{
    public class BookStocksController : Controller
    {
        IBooksStocksService _bookStocksService;
        public BookStocksController(IBooksStocksService bookStocksService)
        {
            _bookStocksService = bookStocksService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BooksStocks bookStocks)
        {
            _bookStocksService.Add(bookStocks);
            return View();
        }
    }
}
