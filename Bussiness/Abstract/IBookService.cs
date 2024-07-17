using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IBookService
    {
        Books GetBooks();
        bool Add(Books books);
        bool Update(Books books);
    }
}
