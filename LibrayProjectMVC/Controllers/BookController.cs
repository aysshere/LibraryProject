

/*
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
*/
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

        // Edit - GET: Book/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Edit - POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BooksDto booksDto)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(booksDto);
                return RedirectToAction("Index");
            }
            return View(booksDto);
        }

        // Delete - POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
