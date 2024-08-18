using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class CartViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookQuantity { get; set; }
        public decimal Price { get; set; }

        


    }
}
