using Bussiness.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibrayProjectMVC.Controllers
{
    // Controllers/CartController.cs
    public class CartController : Controller
    {
        private readonly CartManager _cartManager;

        public CartController(CartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int bookId, int quantity)
        {
            //var userId = User.Identity.Name; // Kullanıcıyı belirleyin
            //await _cartManager.AddToCartAsync(userId, bookId, quantity);
            // return RedirectToAction("Cart"); // Sepeti gösteren sayfaya yönlendir
            return null;
        }

        public async Task<IActionResult> Cart()
        {
            //var userId = User.Identity.Id;
            //var cart = await _cartManager.GetCartAsync(userId);
            return View();
        }
    }

}
