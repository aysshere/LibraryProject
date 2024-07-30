using Bussiness.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using LibrayProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibrayProjectMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Index - GET: Book/Index
        [HttpGet]
        public IActionResult Index()
        {
            var result = _bookService.GetAllBooks();
            var viewBooksModel = new ViewBooksModel
            {
                ListBooks = result
            };
            return View(viewBooksModel);
        }

        // Index - POST: Book/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AddBooksDto booksDto)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(booksDto);
                return RedirectToAction("Index");
            }

            var result = _bookService.GetAllBooks();
            var viewBooksModel = new ViewBooksModel
            {
                ListBooks = result
            };
            return View(viewBooksModel);
        }

        // Index - GET: Book/Index
        [HttpGet]
        public IActionResult AllBooks()
        {
            var result = _bookService.GetAllBooks();
            var viewBooksModel = new ViewBooksModel
            {
                ListBooks = result
            };
            return View(viewBooksModel);
        }
        public IActionResult Update(int id)
        {
            var result = _bookService.GetBookDto(id);
            var viewBooksModel = new ViewBooksModel
            {
                BooksDto = result
            };
            return View(viewBooksModel);
        }

    }
}
