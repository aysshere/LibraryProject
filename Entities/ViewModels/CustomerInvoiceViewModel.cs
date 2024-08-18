
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class CustomerInvoiceViewModel
    {
        public CustomerViewModel customerViewModel { get; set; }
        public BookRentViewModel bookRentViewModel { get; set; }
        public List<CartViewModel> cartItems { get; set; }
    }
}
