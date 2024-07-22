using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bussiness.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bussiness.Concrete
{
    public class UsersBooksManager : IUsersBooksService
    {
        IBooksStocksService _stocksService;
        public UsersBooksManager(IBooksStocksService booksStocksService)
        {
            _stocksService = booksStocksService;
        }
        public bool Add(UsersBooks usersBooks)
        {
            try
            {
                var stockCheck = _stocksService.GetByBooksIdCheckStocks(usersBooks.Id);
                if (stockCheck != null)
                {
                    using (var context = new LibraryProjectContext())
                    {
                        context.USERS_BOOKS.Add(usersBooks);
                        context.SaveChanges();
                        return true;
                    }
                }
                return false;
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the usersBooks.", ex);
            }

            return false;
        }

        public bool Update(UsersBooks usersBooks)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    var existingUsersBooks = context.USERS_BOOKS.FirstOrDefault(ub => ub.Id == usersBooks.Id);
                    if (existingUsersBooks == null)
                    {
                        throw new KeyNotFoundException("UsersBooks not found.");
                    }

                    existingUsersBooks.UserId = usersBooks.UserId;
                    existingUsersBooks.BooksId = usersBooks.BooksId;
                    existingUsersBooks.StartDate = usersBooks.StartDate;
                    existingUsersBooks.EndDate = usersBooks.EndDate;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the usersBooks.", ex);
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    var usersBooks = context.USERS_BOOKS.FirstOrDefault(ub => ub.Id == id);
                    if (usersBooks == null)
                    {
                        throw new KeyNotFoundException("UsersBooks not found.");
                    }

                    context.USERS_BOOKS.Remove(usersBooks);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the usersBooks.", ex);
            }

            return true;
        }

        public UsersBooks GetById(int id)
        {
            using (var context = new LibraryProjectContext())
            {
                var usersBooks = context.USERS_BOOKS.FirstOrDefault(ub => ub.Id == id);
                if (usersBooks == null)
                {
                    throw new KeyNotFoundException("UsersBooks not found.");
                }

                return usersBooks;
            }
        }

        public List<UsersBooks> GetAll()
        {
            using (var context = new LibraryProjectContext())
            {
                return context.USERS_BOOKS.ToList();
            }
        }
    }
}
