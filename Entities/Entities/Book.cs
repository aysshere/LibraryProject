using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PageNumber { get; set; }
        public int StockId { get; set; }
        public string ImageUrl { get; set; }


        public virtual BookStock BookStock { get; set; }
        public virtual Category Category { get; set; }

    }
}
