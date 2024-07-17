using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LibraryProjectContext : DbContext
    {
        public DbSet<Books> BOOKS { get; set; }
        public DbSet<BooksStocks> BOOKS_STOCKS { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-G42T61L;Database=LibraryProject;Trusted_Connection=True;TrustServerCertificate=true;");
        }


    }
}
