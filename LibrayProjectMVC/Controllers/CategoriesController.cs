using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IBookCategoriesService _bookCategoriesService;

        public CategoriesController(IBookCategoriesService bookCategoriesService)
        {
            _bookCategoriesService = bookCategoriesService;
        }

        [HttpGet]
        public ActionResult<List<Categories>> GetAll()
        {
            var categories = _bookCategoriesService.GetAll();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Categories> GetById(int id)
        {
            var category = _bookCategoriesService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Add(Categories category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var result = _bookCategoriesService.Add(category);
            if (!result)
            {
                return StatusCode(500, "An error occurred while adding the category.");
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Categories category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var result = _bookCategoriesService.Update(category);
            if (!result)
            {
                return StatusCode(500, "An error occurred while updating the category.");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _bookCategoriesService.Delete(id);
            if (!result)
            {
                return StatusCode(500, "An error occurred while deleting the category.");
            }

            return Ok();
        }
    }
}
