using Entity.Entities;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CartService : ICartService
    {

        
            /*private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly string CartSessionKey = "CartSession";

            public CartService(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            *//*public List<Cart> GetCart()
            {
                var session = _httpContextAccessor.HttpContext.Session;
                var cart = session.GetObjectFromJson<List<Cart>>(CartSessionKey) ?? new List<Cart>();
                return cart;
            }*//*

            public void AddToCart(Cart item)
            {
                var cart = GetCart();
                var existingItem = cart.FirstOrDefault(i => i.ProductId == item.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    cart.Add(item);
                }

                SaveCart(cart);
            }

            public void RemoveFromCart(int productId)
            {
                var cart = GetCart();
                cart.RemoveAll(i => i.ProductId == productId);
                SaveCart(cart);
            }

            public void ClearCart()
            {
                SaveCart(new List<Cart>());
            }

            public int GetTotalQuantity()
            {
                return GetCart().Sum(i => i.Quantity);
            }

            public decimal GetTotalPrice()
            {
                return GetCart().Sum(i => i.TotalPrice);
            }

            private void SaveCart(List<Cart> cart)
            {
                _httpContextAccessor.HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            }*/
        }
}
