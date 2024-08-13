using Entity.UnitOfWorks;
using LibrayProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibrayProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController( IUnitOfWork unitOfWork)
        {
           // _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var books = unitOfWork.Book.GetAll();
            return View(books);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
