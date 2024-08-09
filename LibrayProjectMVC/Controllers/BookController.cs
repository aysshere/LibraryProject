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
            _bookService.Add(booksDto);
            var result = _bookService.GetAllBooks();
            var viewBooksModel = new ViewBooksModel
            {
                ListBooks = result
            };
            return View(viewBooksModel);
        }

        // Index - GET: Book/Index
        //[HttpGet]
        public IActionResult AllBooks()
        {
            var result = _bookService.GetAllBooks();
            var viewBooksModel = new ViewBooksModel
            {
                ListBooks = result
            };
            return View(viewBooksModel);
        }

		[HttpGet]
		public IActionResult Update(int id)
		{
			var result = _bookService.GetBookDto(id);

			var viewBooksModel = new ViewBooksModel
			{
				BooksDto = new BooksDto
				{
					BooksId = result.BooksId,
					BooksStocksId = result.BooksStocksId,
					Author = result.Author,
					PageNumber = result.PageNumber,
					Publisher = result.Publisher,
					BookCode = result.BookCode,
					Name = result.Name,
					Total = result.Total
				}
			};

			return View(viewBooksModel);
		}

		[HttpPost]
        public IActionResult Update(UpdateBooksDto updateBooksDto)
        {

			if (updateBooksDto == null || updateBooksDto.BooksId <= 0)
            {
                return BadRequest("Invalid data.");
            }

            var isUpdated = _bookService.Update(updateBooksDto);

            if (isUpdated)
            {
                return Ok("Book updated successfully.");
            }
            else
            {
                return NotFound("Book not found.");
            }
        }
    }
}
