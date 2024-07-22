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
        List<Books> GetAllBooks();
        Books GetBooks(int id);
        bool Add(Books books);
        bool Update(Books books);
    }
}
