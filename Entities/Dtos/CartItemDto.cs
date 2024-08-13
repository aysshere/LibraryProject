using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
    }
}
