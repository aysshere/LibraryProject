using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class BookStockViewModel
    {
        public int TotalQuantity { get; set; }
        public int RentedQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
