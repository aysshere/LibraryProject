
using Entity.Models;
using LibrayProjectMVC.CartTest;
using Microsoft.AspNetCore.Mvc;
using Service.Extensions;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class CartController : Controller
    {
        private readonly IMovieRepository _movieRepo;

        public CartController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        List<CartItem> cart = new List<CartItem>();     //sepet
        CartItem cartItem = new CartItem();             //sipariş
        public IActionResult Index()    //sepeti görüntüler.
        {
            cart = GetCart();  //Session'dan sepeti alıyoruz.
            TempData["ToplamAdet"] = cartItem.TotalQuantity(cart);
            if (cartItem.TotalPrice(cart) > 0)
                TempData["ToplamTutar"] = cartItem.TotalPrice(cart);
            return View(cart);
        }
        public IActionResult Add(int Id, int Adet)
        {
            var movie = _movieRepo.Get(Id);  //sipariş edilecek movie

            cart = GetCart();               //sepetimi istiyorum (ilk olarak boş sepet)

            cartItem.BookId = movie.Id;    //sipariş oluşturuyoruz.
            cartItem.BookName = movie.Name;
            cartItem.BookQuantity = Adet;
            cartItem.BookPrice = movie.Price;

            cart = cartItem.AddToCart(cart, cartItem); //yeni siparişi sepete ekliyoruz.

            SetCart(cart);

            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            cart = GetCart();
            cart = cartItem.DeleteFromCart(cart, id);
            SetCart(cart);      //session'a sepetin son halini kayıt ediyoruz.
            return RedirectToAction("Index");
        }
        public void SetCart(List<CartItem> sepet)   //sepet kayıt (json formatta) eder.
        {
            HttpContext.Session.SetJson("sepet", sepet);    //alışveriş sepetimizi sepet isimli (key) session'a kayıt ediyoruz.
        }
        public List<CartItem> GetCart()     //kayıtlı sepeti (text formatta) getirir.
        {
            var sepet = HttpContext.Session.GetJson<List<CartItem>>("sepet") ?? new List<CartItem>();
            //?? -> ilk başta sepet olmadığından null gelir, bize boş bir sepet döndürür.
            return sepet;
        }
        public IActionResult DeleteCart()
        {
            //HttpContext.Session.Clear(); //Oturumda bulunan tüm session'ları siler.
            HttpContext.Session.Remove("sepet"); //Sadece adı sepet olan session'ı siler.
            return RedirectToAction("Index");
        }
    }
}
