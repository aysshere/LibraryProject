using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class BookStock
    {
        public int Id { get; set; }
            
        public int TotalQuantity { get; set; }      
        public int RentedQuantity { get; set; }

        public int AvailableQuantity { get; set; }

    }
}
