using Entity.Entities;
using Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class BookRentViewModel
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<BookRentDetail> BookRentDetails { get; set; }
        public virtual AppUser User { get; set; }

    }
}
