using Microsoft.AspNetCore.Mvc;

namespace LibrayProjectMVC.Controllers
{
    public class UsersBooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
