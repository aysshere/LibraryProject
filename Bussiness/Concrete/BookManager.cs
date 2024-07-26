using Bussiness.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public bool Add(AddBooksDto addBooksDto)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    Books books = new Books()
                    {
                        Name = addBooksDto.Name,
                        BookCode = addBooksDto.BookCode,
                        Author = addBooksDto.Author,
                        PageNumber = addBooksDto.PageNumber,
                        Publisher = addBooksDto.Publisher,
                    };

                    context.BOOKS.Add(books);
                    context.SaveChanges();
                    BooksStocks booksStocks = new BooksStocks()
                    {
                        BookId = books.Id,
                        Total = addBooksDto.Total
                    };
                    _booksStocksService.Add(booksStocks);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public bool Delete(int id)
        {
            using (var context = new LibraryProjectContext())
            {
                try
                {
                    var getBooks = GetBooks(id);
                    context.Remove(getBooks);
                    context.SaveChanges();
                    var getBooksStock = _booksStocksService.GetByBooksId(id);
                    _booksStocksService.Delete(getBooksStock);
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
                return false;
            }
        }

        public List<BooksDto> GetAllBooks()
        {
            using (LibraryProjectContext context = new LibraryProjectContext())
            {
                var result = from b in context.BOOKS
                             join bs in context.BOOKS_STOCKS
                             on b.Id equals bs.BookId
                             select new BooksDto
                             {
                                 Id = b.Id,
                                 Name = b.Name,
                                 Author = b.Author,
                                 Publisher = b.Publisher,
                                 PageNumber = b.PageNumber,
                                 BookCode = b.BookCode,
                                 Total = bs.Total
                             };
                
                return result.ToList();
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

        public void Update(BooksDto booksDto)
        {
            throw new NotImplementedException();
        }

        
    }
}
