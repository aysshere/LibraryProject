using Entity.Entities;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IBookService
    {
        Task<string> AddBookAsync(BookViewModel model);

        Task<string> UpdateBookAsync(BookViewModel model);

        Task<string> DeleteBookAsync(int gameId);

        Task<BookViewModel> GetBookByIdAsync(int gameId);

        Task<List<BookViewModel>> GetAllBooksAsync();

        Task<List<BookViewModel>> SearchBooksAsync(string searchTerm);

        Task<List<BookViewModel>> GetBooksByCategoryAsync(int categoryId);
        
    }
}
