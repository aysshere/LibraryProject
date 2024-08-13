using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryProjectDb db;

        public UnitOfWork(LibraryProjectDb db)
        {
            this.db = db;
        }

        public IBookService Book => new BookRepository(db);


        public IBookRentDetailService BookRentDetail => new BookRentDetailRepository(db);

        public IBookRentService BookRent => new BookRentRepository(db);

        public IBookStockRepository BookStock =>  new BookStockRepository(db);

        public ICategoryService Category => new CategoryRepository(db);

        public ICustomerService Customer => new CustomerRepository(db);

        public ICustomerRentRepository CustomerRent => new CustomerRentRepository(db);

        public void Dispose()
        {
            db.SaveChanges();
        }

        public void Save()
        {
            db.Dispose();
        }
    }
}
