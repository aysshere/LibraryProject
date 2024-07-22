using Bussiness.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class BookManager : IBookService
    {
        IBooksStocksService _booksStocksService;
        public BookManager(IBooksStocksService booksStocksService)
        {
            _booksStocksService = booksStocksService;
        }
        public bool Add(Books books)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    context.BOOKS.Add(books);
                    context.SaveChanges();
                    BooksStocks booksStocks = new BooksStocks()
                    {
                        BookId = books.Id,
                        Status  = true
                    };
                    _booksStocksService.Add(booksStocks);

                }
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }

            return true;
        }

        public List<Books> GetAllBooks()
        {
            using (var context = new LibraryProjectContext())
            {
                var books = context.BOOKS.ToList();
                if(books != null && books.Count()<0)
                {
                    return null;
                }
                return books;
            }

        }

        public Books GetBooks(int id) 
        {
            using (var context = new LibraryProjectContext())
            { 
                var books= context.BOOKS.FirstOrDefault(x => x.Id == id);
                return books;
            }  
        }

        public bool Update(Books books)
        {
            throw new NotImplementedException();
        }
    }
}
