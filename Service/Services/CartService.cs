using Entity.Entities;
using Entity.Interfaces;
using Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
        private readonly ISession _session;
        private const string CartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public async Task<List<CartViewModel>> AddToCartAsync(List<CartViewModel> cart, CartViewModel cartItem)
        {
            var item = cart.FirstOrDefault(c => c.BookId == cartItem.BookId);
            if (item != null)
            {
                item.BookQuantity += cartItem.BookQuantity;
            }
            else
            {
                cart.Add(cartItem);
            }

            SaveCart(cart);
            return cart;
        }

        public async Task<List<CartViewModel>> DeleteFromCartAsync(List<CartViewModel> cart, int id)
        {
            cart.RemoveAll(c => c.BookId == id);
            SaveCart(cart);
            return cart;
        }

        public async Task<int> GetTotalQuantityAsync(List<CartViewModel> cart)
        {
            return cart.Sum(c => c.BookQuantity);
        }

        public async Task<decimal> GetTotalPriceAsync(List<CartViewModel> cart)
        {
            return cart.Sum(c => c.BookQuantity * c.Price);
        }

        private void SaveCart(List<CartViewModel> cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            _session.SetString(CartSessionKey, cartJson);
        }

        public List<CartViewModel> GetCartFromSession()
        {
            var cartJson = _session.GetString(CartSessionKey);
            return string.IsNullOrEmpty(cartJson) ? new List<CartViewModel>() : JsonConvert.DeserializeObject<List<CartViewModel>>(cartJson);
        }


    }
}
