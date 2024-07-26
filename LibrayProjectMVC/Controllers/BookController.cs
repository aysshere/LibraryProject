using Bussiness.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using LibrayProjectMVC.Models;
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
            var result = _bookService.GetAllBooks();
            
            ViewBooksModel viewBooksModel  = new ViewBooksModel();
            viewBooksModel.ListBooks = result;
            return View(viewBooksModel);
        }
        [HttpPost]
        public IActionResult Index(AddBooksDto books)
        {
            _bookService.Add(books);
            var result = _bookService.GetAllBooks();
            ViewBooksModel viewBooksModel = new ViewBooksModel();
            viewBooksModel.ListBooks = result;
            return View(viewBooksModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
