using DataAccess.Context;
using Entity.Entities;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookStockRepository : GenericRepository<BookStock>, IBookStockRepository
    {
        private readonly LibraryProjectDb db;
        public BookStockRepository(LibraryProjectDb db) : base(db)
        {
            this.db = db;
        }
    }
}
