using Entities.Concrete;
using Entities.Dtos;

namespace LibrayProjectMVC.Models
{
    public class ViewBooksModel
    {
        public List<BooksDto> ListBooks { get; set; }
        public BooksDto BooksDto { get; set; }
    }
}
