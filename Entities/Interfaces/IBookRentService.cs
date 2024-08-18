using Entity.Entities;

using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IBookRentService
    {
        bool AddRange(List<CartViewModel> cart, int satisId);
        public int AddRent(BookRent bookRent);
    }
}
