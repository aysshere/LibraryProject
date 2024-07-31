using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IBooksStocksService
    {
        BooksStocks GetByBooksId(int bookId);
        bool Add(BooksStocks booksStocks);
        bool Delete(BooksStocks booksStocks);
        bool Update(BooksStocks booksStocks);
        
        BooksStocks GetByBooksIdCheckStocks(int bookId);
    }
}
