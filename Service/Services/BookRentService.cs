using DataAccess.Context;
using Entity.Entities;
using Entity.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookRentService : IBookRentService
    {
        private readonly LibraryProjectDb _libraryProjectDb;

        public BookRentService(LibraryProjectDb libraryProjectDb)
        {
            _libraryProjectDb = libraryProjectDb;
        }

        public bool AddRange(List<CartItem> cart, int satisId)
        {
            foreach (var item in cart)
            {
                BookRentDetail yeniSiparis = new BookRentDetail()
                {
                    BookRentId = satisId,
                    BookId = item.BookId,
                    Quantity = item.BookQuantity,
                     UnitPrice = item.BookPrice
                };
                _libraryProjectDb.BookRentDetails.Add(yeniSiparis); // Ara katmana ekler
            }
            try
            {
                _libraryProjectDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return false;
        }

        public int AddRent(BookRent bookRent)
        {
            _libraryProjectDb.BookRents.Add(bookRent);     //ara katmana ekler.
            _libraryProjectDb.SaveChanges();         //veritabanına ekler ve sql id değerini atar.
            return bookRent.Id;
        }
    }
}
