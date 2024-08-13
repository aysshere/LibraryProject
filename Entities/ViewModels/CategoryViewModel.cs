using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
