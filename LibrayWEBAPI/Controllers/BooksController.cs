using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Books books)
        {
            var result = _bookService.Add(books);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
