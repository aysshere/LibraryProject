using AutoMapper;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }


        public async Task<string> AddBookAsync(BookViewModel model)
        {
            var book = _mapper.Map<Book>(model);
            var repository = _unitOfWork.GetRepository<Book>();
            await repository.Add(book);
            _unitOfWork.Commit();
            return "Book added successfully.";
        }

        public async Task<string> DeleteBookAsync(int bookId)
        {
            var repository = _unitOfWork.GetRepository<Book>();
            var book = await repository.GetByIdAsync(bookId);
            if (book == null)
            {
                return "Book not found.";
            }

            repository.Delete(book);
            _unitOfWork.Commit();
            return "Book deleted successfully.";
        }

        public async Task<List<BookViewModel>> GetAllBooksAsync()
        {
            var repository = _unitOfWork.GetRepository<Book>();
            var books = await repository.GetAllAsync();
            return _mapper.Map<List<BookViewModel>>(books);
        }

        public async Task<BookViewModel> GetBookByIdAsync(int bookId)
        {
            var repository = _unitOfWork.GetRepository<Book>();
            var book = await repository.GetByIdAsync(bookId);
            if (book == null)
            {
                return null;
            }

            return _mapper.Map<BookViewModel>(book);

        }

        public async Task<List<BookViewModel>> GetBooksByCategoryAsync(int categoryId)
        {
            var repository = _unitOfWork.GetRepository<Book>();
            var books = await repository.GetAll(
                filter: g => g.CategoryId == categoryId // Assuming "CategoryId" is a foreign key in Game entity
            );
            return _mapper.Map<List<BookViewModel>>(books);
        }



        public async Task<List<BookViewModel>> SearchBooksAsync(string searchTerm)
        {
            var repository = _unitOfWork.GetRepository<Book>();
            var books = await repository.GetAll(
                filter: g => g.Name.Contains(searchTerm) || g.Description.Contains(searchTerm)
            );
            return _mapper.Map<List<BookViewModel>>(books);
        }

        public async Task<string> UpdateBookAsync(BookViewModel model)
        {
            var repository = _unitOfWork.GetRepository<Book>();
            var book = await repository.GetByIdAsync(model.Id);
            if (book == null)
            {
                return "Book not found.";
            }

            _mapper.Map(model, book);
            repository.Update(book);
            _unitOfWork.Commit();
            return "Book updated successfully.";
        }
    }
}
