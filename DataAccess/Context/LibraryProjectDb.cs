
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LibraryProjectDb : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRent> BookRents { get; set; }
        public DbSet<BookRentDetail> BookRentDetails { get; set; }
        public DbSet<BookStock> BookStocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRent> CustomerRents { get; set; }
        


    }
}
