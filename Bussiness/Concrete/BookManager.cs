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
        public bool Add(Books books)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    context.BOOKS.Add(books);
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

        public Books GetBooks()
        {
            throw new NotImplementedException();
        }

        public bool Update(Books books)
        {
            throw new NotImplementedException();
        }
    }
}
