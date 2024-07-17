using Bussiness.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bussiness.Concrete
{
    public class BookStocksManager : IBooksStocksService
    {
        public bool Add(BooksStocks booksStocks)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    context.BOOKS_STOCKS.Add(booksStocks);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
            return true;
        }
    }
}
