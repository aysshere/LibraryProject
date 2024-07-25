using Microsoft.AspNetCore.Mvc;

using Bussiness.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller 
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<Users> GetById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                return Ok(user);
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
        public ActionResult Add(Users user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            try
            {
                var result = _userService.Add(user);
                if (!result)
                {
                    return StatusCode(500, "An error occurred while adding the user.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(Users user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            try
            {
                var result = _userService.Update(user);
                if (!result)
                {
                    return StatusCode(500, "An error occurred while updating the user.");
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
                var result = _userService.Delete(id);
                if (!result)
                {
                    return StatusCode(500, "An error occurred while deleting the user.");
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
