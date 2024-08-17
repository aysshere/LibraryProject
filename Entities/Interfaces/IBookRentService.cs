using Entity.Entities;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IBookRentService
    {
        bool AddRange(List<CartItem> cart, int satisId);
        public int AddRent(BookRent bookRent);
    }
}
