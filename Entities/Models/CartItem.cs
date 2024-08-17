namespace Entity.Models
{
    public class CartItem
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookQuantity { get; set; }
        public decimal BookPrice { get; set; }

        public List<CartItem> AddToCart(List<CartItem> cart, CartItem cartItem)
        {
            //if(cart.Any(c => c.MovieId == cartItem.MovieId)) {  sipariş sepette varsa true döner.
            //    //ürünü bulup adet artırılacak.
            //}
            var item = cart.Find(c => c.BookId == cartItem.BookId);  //sepette yeni siparişle aynı üründen varsa yakalar.
            if(item != null)
            {
                item.BookQuantity += cartItem.BookQuantity;  //aynı ürünü bulup miktarını yeni siparişin miktarı kadar artırıyoruz.
            }
            else
            {
                cart.Add(cartItem);         //siparişi sepete ekler.
            }
            return cart;  
        }
        public List<CartItem> DeleteFromCart(List<CartItem> cart, int id)
        {
            cart.RemoveAll(c => c.BookId == id);
            return cart;
        }
        public int TotalQuantity(List<CartItem> cart)
        {
            int total = cart.Sum(c => c.BookQuantity);
            return total;
        }
        public decimal TotalPrice(List<CartItem> cart)
        {
            decimal total = cart.Sum(c => c.BookQuantity * c.BookPrice);
            return total;
        }
    }
}
