

using Entity.Entities;

namespace LibrayProjectMVC.CartTest
{
    public interface IMovieRepository
    {
        public List<Book> GetAll();
        public Book Get(int id);

        public void Add(Book movie);
        public void Update(Book movie);
        public void Delete(int id);
        public void Delete(Book movie);
    }
}
