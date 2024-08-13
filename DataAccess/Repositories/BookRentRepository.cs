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
    public class BookRentRepository : GenericRepository<BookRent>, IBookRentService
    {
        private readonly LibraryProjectDb db;
        public BookRentRepository(LibraryProjectDb db) : base(db)
        {
            this.db = db;
        }
    }
}
