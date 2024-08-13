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
    public class BookRepository : GenericRepository<Book>, IBookService
    {
        private readonly LibraryProjectDb db;
        public BookRepository(LibraryProjectDb db) : base(db)
        {
            this.db = db;
        }
    }
}
