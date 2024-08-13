using Bussiness.Abstract;
using DataAccess.Context;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    // Manager/CartManager.cs
    public class CartManager : ICartService
    {
        private readonly ICartService _cartRepository;

        public CartManager( )
        {
        }

        public CartDto GetCartAsync(int userId)
        {
            using (LibraryProjectContext context = new LibraryProjectContext())
            {
                var result = from c in context.CART
                             join b in context.BOOKS
                             on c.BookId equals b.Id
                             join u in context.USERS
                             on c.UserId equals u.Id
                             where u.Id == userId
                             select new CartDto
                             {
                                 CartId = c.Id,
                                 BookId = b.Id,
                                 BookName = b.Name,
                                 Quantity = c.Quantity
                             };

                //return result.ToList();
                return null;
            }
        }

        private static object GetCartItemId(int id)
        {
            //var cart;
            return null;
        }

        public bool AddToCartAsync(string userId, int bookId, int quantity)
        {
            _cartRepository.AddToCartAsync(userId, bookId, quantity);
            return true;
        }

        List<CartDto> ICartService.GetCartAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }

}
