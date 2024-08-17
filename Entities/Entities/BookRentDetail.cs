using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class BookRentDetail : BaseEntity
    {
        
        public int BookRentId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual BookRent BookRent { get; set; }
        public virtual Book Book { get; set; }
    }
}
