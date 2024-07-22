using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AddBooksDto
    {
        public int BooksId { get; set; }
        /// <summary>
        /// Kitap Adi
        /// </summary>
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PageNumber { get; set; }
        public string BookCode { get; set; }
        public int Total { get; set; }
    }
}
