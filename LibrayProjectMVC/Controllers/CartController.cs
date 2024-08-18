using Entity.Interfaces;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Extensions;

namespace LibrayProjectMVC.Controllers
{
    public class CartController : Controller
    {
        
        private readonly ICartService _cartService;
        private readonly IBookService _bookService;

        public CartController(ICartService cartService, IBookService bookService)
        {

            _cartService = cartService;
            _bookService = bookService;
        }

        public IActionResult Index() // Displays the cart
        {
            try
            {
                var cart = GetCart();  // Retrieve the cart from the session

                // Convert decimal values to string before storing in TempData
                TempData["TotalQuantity"] = _cartService.GetTotalQuantityAsync(cart).Result.ToString();
                TempData["TotalPrice"] = _cartService.GetTotalPriceAsync(cart).Result.ToString("F2"); // "F2" formats to 2 decimal places

                return View(cart);
            }
            catch (Exception ex)
            {
                // Log the exception (you can log this to a file or a logging service)
                Console.WriteLine(ex.ToString());
                // Optionally, show a user-friendly error message
                return View("Error");
            }
        }
        public async Task<IActionResult> Add(int id, int quantity)
        {
            // Assuming you have a way to fetch book details, you need to replace `_movieRepo.Get(id)` 
            // with the appropriate method to fetch the book by its ID.

            var book = await _bookService.GetBookByIdAsync(id);  // Fetch the book to be added to the cart

            var cart = GetCart();  // Retrieve the cart from the session

            var cartItem = new CartViewModel
            {
                BookId = book.Id,
                BookName = book.Name,
                BookQuantity = quantity,
                Price = book.Price
            };

            cart = _cartService.AddToCartAsync(cart, cartItem).Result; // Add the new item to the cart

            SetCart(cart);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var cart = GetCart();  // Retrieve the cart from the session
            cart = _cartService.DeleteFromCartAsync(cart, id).Result;  // Remove the item from the cart
            SetCart(cart);  // Save the updated cart back to the session

            return RedirectToAction("Index");
        }
        public void SetCart(List<CartViewModel> cart)  // Saves the cart to the session
        {
            HttpContext.Session.SetJson("cart", cart);  // Save the cart as a JSON string in the session
        }
        public List<CartViewModel> GetCart()  // Retrieves the cart from the session
        {
            return HttpContext.Session.GetJson<List<CartViewModel>>("cart") ?? new List<CartViewModel>();
        }
        public IActionResult ClearCart()  // Clears the cart from the session
        {
            HttpContext.Session.Remove("cart");  // Remove the "cart" session
            return RedirectToAction("Index");
        }
    }
}
