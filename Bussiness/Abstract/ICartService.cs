using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    // Abstract/ICartRepository.cs
    public interface ICartService
    {
        List<CartDto> GetCartAsync(int userId);
        bool AddToCartAsync(string userId, int bookId, int quantity);
    }

}
