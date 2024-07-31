using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IBookService
    {
        List<BooksDto> GetAllBooks();
        BooksDto GetBookDto(int id);
        Books GetBooks(int id);
        bool Add(AddBooksDto addBooksDto);
        bool Delete(int id);
        bool Update(UpdateBooksDto updatebooksDto);
		
		
	}
}
