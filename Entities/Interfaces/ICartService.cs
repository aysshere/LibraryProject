using Entity.Entities;

using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ICartService
    {
        Task<List<CartViewModel>> AddToCartAsync(List<CartViewModel> cart, CartViewModel cartItem);
        Task<List<CartViewModel>> DeleteFromCartAsync(List<CartViewModel> cart, int id);
        Task<int> GetTotalQuantityAsync(List<CartViewModel> cart);
        Task<decimal> GetTotalPriceAsync(List<CartViewModel> cart);


    }
}
