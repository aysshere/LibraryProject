using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassLibraryWEBAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       Ibook
        public BooksController(IBookService)
        {
            
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllAccesory(Books books)
        {
            //var result = _accessoryService.GetAllAccessory();

            //if (result.Success)
            //{
            //    return Ok(result);
            //}

            //return BadRequest(result);
            return null;
        }

        [HttpGet("Add")]
        public IActionResult Add(Books books)
        {
            var result = _accessoryService.GetAllAccessory();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
            return null;
        }
    }
}
