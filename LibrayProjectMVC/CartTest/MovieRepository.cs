

using DataAccess.Context;
using Entity.Entities;

namespace LibrayProjectMVC.CartTest
{
    public class MovieRepository : IMovieRepository
    {
        private readonly LibraryProjectDb _context;

        public MovieRepository(LibraryProjectDb context)   //DI Container'dan nesne istiyoruz.
        {
            _context = context;
        }
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }
        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }
        public void Add(Book movie)
        {
            _context.Books.Add(movie);     //ara katmana ekler.
            _context.SaveChanges();         //veritabanına ekler.
        }
        public void Delete(int id)
        {
            _context.Books.Remove(Get(id));    //Önce id'den nesneyi buluyor, ardından siliyor.
            _context.SaveChanges();             //veritabanından siler.
        }
        public void Delete(Book movie)
        {
            _context.Books.Remove(movie);      //Doğrudan nesneyi ara katmandan siliyor.
            _context.SaveChanges();
        }
        public void Update(Book movie)
        {
            _context.Books.Update(movie);      //Verilen nesneyi ara katmanda günceller.
            _context.SaveChanges();             //veritabanı güncellenir.
        }
    }
}
