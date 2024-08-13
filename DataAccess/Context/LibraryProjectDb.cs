﻿
using DataAccess.Identity;
using Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LibraryProjectDb : IdentityDbContext<AppUser,AppRole,int>
    {
        public LibraryProjectDb(DbContextOptions<LibraryProjectDb> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRent> BookRents { get; set; }
        public DbSet<BookRentDetail> BookRentDetails { get; set; }
        public DbSet<BookStock> BookStocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRent> CustomerRents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.ImageUrl).HasDefaultValue("/img/bookimg.jpg");
            modelBuilder.Entity<Book>().
                HasOne(b => b.BookStock).
                WithMany(bs => bs.Books).
                HasForeignKey(b => b.StockId);

            modelBuilder.Entity<Book>().
                HasOne(b=>b.Category).
                WithMany(c=>c.Books).
                HasForeignKey(b => b.CategoryId);
            
            

            modelBuilder.Entity<BookRent>().
                HasOne(br=>br.Customer).
                WithMany(c=>c.BookRents).
                HasForeignKey(b=>b.CustomerId);

            modelBuilder.Entity<BookRentDetail>().
                HasOne(br=>br.BookRent).
                WithMany(b=>b.BookRentDetails).
                HasForeignKey(bsd=>bsd.BookRentId);

            modelBuilder.Entity<BookRentDetail>().
                HasOne(brd=>brd.Book).
                WithMany().
                HasForeignKey(b=>b.BookId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
