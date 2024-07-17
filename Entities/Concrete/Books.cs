using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Books
    {
        public int Id { get; set; }
        /// <summary>
        /// Kitap Adi
        /// </summary>
        public string Name  { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PageNumber { get; set; }
        public string BookCode { get; set; }
    }
}
