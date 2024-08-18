using AutoMapper;
using DataAccess.Context;
using Entity.Identity;
using Entity.Entities;
using Entity.Interfaces;
using Entity.ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Extensions;

namespace LibrayProjectMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBookRentService _bookRentService;
        private readonly IMapper _mapper;
        private readonly LibraryProjectDb _libraryProjectDb;
        private readonly ICartService _cartService;
        List<CartViewModel> cart = new List<CartViewModel>();
        CartViewModel cartItem = new CartViewModel();
        public AccountController(IAccountService accountService, SignInManager<AppUser> signInManager, IMapper mapper, LibraryProjectDb libraryProjectDb, ICartService cartService)
        {
            _accountService = accountService;
            _signInManager = signInManager;
            _mapper = mapper;
            _libraryProjectDb = libraryProjectDb;
            _cartService = cartService;
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
                var customer = await _accountService.FindCustomerByNameAsync(model); // Adjust this line according to your service method that fetches the customer.

                if (customer != null)
                {
                    HttpContext.Session.SetJson("user", customer);  // Store the customer object in the session
                    return RedirectToAction("ConfirmAddress");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                               

                string msg = await _accountService.CreateUserAsync(model);
                if (msg == "OK")
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", msg);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ConfirmAddress()
        {
            //Güvenlik için login olan kullanıcı bilgilerini session'dan çağırıp kontrol ediyoruz.
            var customerViewModel = HttpContext.Session.GetJson<CustomerViewModel>("user");
            if (customerViewModel == null)
            {
                return RedirectToAction("Login");
            }
            return View(customerViewModel); // No need to map since it's already a CustomerViewModel
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmAddress(CustomerViewModel model)
        {
            var user = _mapper.Map<AppUser>(model);
            await _accountService.UpdateAsync(user);  // Use the async update method
            HttpContext.Session.SetJson("user", model); // Store the updated CustomerViewModel
            return RedirectToAction("ConfirmPayment", "Account");
        }

        public async Task<IActionResult> ConfirmPayment()
        {
            var customer = HttpContext.Session.GetJson<AppUser>("user");
            if (customer == null)
            {
                TempData["mesaj"] = "Oturumunuz sona erdi. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Login");
            }

            cart = HttpContext.Session.GetJson<List<CartViewModel>>("sepet");
            if (cart == null || !cart.Any())
            {
                TempData["mesaj"] = "Sepetiniz boş.";
                return RedirectToAction("Index", "Cart");
            }

            int totalQuantity = await _cartService.GetTotalQuantityAsync(cart);
            decimal totalPrice = await _cartService.GetTotalPriceAsync(cart);

            BookRentViewModel bookRentViewModel = new BookRentViewModel
            {
                RentDate = DateTime.Now,
                CustomerId = customer.Id,
                TotalQuantity = totalQuantity,
                TotalPrice = totalPrice
            };

            CustomerInvoiceViewModel customerInvoiceViewModel = new CustomerInvoiceViewModel
            {
                customerViewModel = _mapper.Map<CustomerViewModel>(customer),
                bookRentViewModel = bookRentViewModel,
                cartItems = cart
            };

            return View(customerInvoiceViewModel);
        }


        [HttpPost]
        public IActionResult ConfirmPayment(CustomerInvoiceViewModel model)
        {
            if (model == null || model.bookRentViewModel == null)
            {
                TempData["mesaj"] = "Ödeme işlemi için gerekli bilgiler eksik.";
                return RedirectToAction("ConfirmPayment");
            }

            // Retrieve the customer from the session
            var customer = HttpContext.Session.GetJson<AppUser>("user");
            if (customer == null)
            {
                TempData["mesaj"] = "Oturumunuz sona erdi. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Login");
            }

            // Ensure the CustomerId is set in the BookRentViewModel
            model.bookRentViewModel.CustomerId = customer.Id;

            // Map the model to a BookRent entity
            var bookRent = _mapper.Map<BookRent>(model.bookRentViewModel);
            if (bookRent == null)
            {
                TempData["mesaj"] = "Veritabanına kayıt sırasında bir sorun oluştu.";
                return RedirectToAction("ConfirmPayment");
            }

            // Save the BookRent entity and get the generated Id
            var satisId = _bookRentService.AddRent(bookRent);
            if (satisId == 0)
            {
                TempData["mesaj"] = "Veritabanına kayıt sırasında bir sorun oluştu.";
                return RedirectToAction("ConfirmPayment");
            }

            // Retrieve the cart from the session
            var cart = HttpContext.Session.GetJson<List<CartViewModel>>("sepet");
            if (cart == null || !cart.Any())
            {
                TempData["mesaj"] = "Sepetiniz boş.";
                return RedirectToAction("Index", "Cart");
            }

            if (!_bookRentService.AddRange(cart, satisId))
            {
                TempData["mesaj"] = "Satış işlemi gerçekleşmedi, bilgilerinizi kontrol edin.";
                return View("MessageShow");
            }

            TempData["mesaj"] = "Satış işlemi başarıyla tamamlandı.";
            HttpContext.Session.Remove("sepet");

            return View("MessageShow");
        }









    }
}
