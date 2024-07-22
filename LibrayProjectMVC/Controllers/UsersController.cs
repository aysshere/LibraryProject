using Microsoft.AspNetCore.Mvc;

namespace LibrayProjectMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
