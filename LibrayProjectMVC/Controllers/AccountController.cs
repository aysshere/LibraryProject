using Bussiness.Abstract;

using DataAccess.Identity;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibrayProjectMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = ReturnUrl ?? Url.Content("~/") // Default to home page if null
            };
            TempData["message"] = null;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string result = await _accountService.FindByNameAsync(model);

                if (result == "OK")
                {


                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", result);
                }
            }

            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    //string msg = await _accountService.CreateUserAsync(model);
        //    //if (msg == "OK")
        //    //{
        //    //    return RedirectToAction("Login");
        //    //}
        //    //else
        //    //{
        //    //    ModelState.AddModelError("", msg);
        //    //}
        //    //return View(model);
        //    return(
        //}
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
