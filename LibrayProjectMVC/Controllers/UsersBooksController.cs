using Microsoft.AspNetCore.Mvc;

using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersBooksController : ControllerBase
    {
        private readonly IUsersBooksService _usersBooksService;

        public UsersBooksController(IUsersBooksService usersBooksService)
        {
            _usersBooksService = usersBooksService;
        }

        [HttpGet]
        public ActionResult<List<UsersBooks>> GetAll()
        {
            var usersBooks = _usersBooksService.GetAll();
            return Ok(usersBooks);
        }

        [HttpGet("{id}")]
        public ActionResult<UsersBooks> GetById(int id)
        {
            try
            {
                var usersBooks = _usersBooksService.GetById(id);
                return Ok(usersBooks);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Add(UsersBooks usersBooks)
        {
            if (usersBooks == null)
            {
                return BadRequest("UsersBooks cannot be null.");
            }

            try
            {
                var result = _usersBooksService.Add(usersBooks);
                if (!result)
                {
                    return StatusCode(500, "An error occurred while adding the usersBooks.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(UsersBooks usersBooks)
        {
            if (usersBooks == null)
            {
                return BadRequest("UsersBooks cannot be null.");
            }

            try
            {
                var result = _usersBooksService.Update(usersBooks);
                if (!result)
                {
                    return StatusCode(500, "An error occurred while updating the usersBooks.");
                }

                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _usersBooksService.Delete(id);
                if (!result)
                {
                    return StatusCode(500, "An error occurred while deleting the usersBooks.");
                }

                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
