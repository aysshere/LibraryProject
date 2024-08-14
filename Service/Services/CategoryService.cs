using AutoMapper;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }


        public async Task<string> AddCategoryAsync(CategoryViewModel model)
        {
            var category = _mapper.Map<Category>(model);
            var repository = _unitOfWork.GetRepository<Category>();
            await repository.Add(category);
            _unitOfWork.Commit();
            return "Category added successfully.";
        }

        public async Task<string> DeleteCategoryAsync(int categoryId)
        {
            var repository = _unitOfWork.GetRepository<Category>();
            var category = await repository.GetByIdAsync(categoryId);
            if (category == null)
            {
                return "Category not found.";
            }

            repository.Delete(category);
            _unitOfWork.Commit();
            return "Category deleted successfully.";
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var repository = _unitOfWork.GetRepository<Category>();
            var categories = await repository.GetAllAsync();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int categoryId)
        {
            var repository = _unitOfWork.GetRepository<Category>();
            var category = await repository.GetByIdAsync(categoryId);
            if (category == null)
            {
                return null;
            }

            return _mapper.Map<CategoryViewModel>(category);

        }

        



        

        public async Task<string> UpdateCategoryAsync(CategoryViewModel model)
        {
            var repository = _unitOfWork.GetRepository<Category>();
            var category = await repository.GetByIdAsync(model.Id);
            if (category == null)
            {
                return "Category not found.";
            }

            _mapper.Map(model, category);
            repository.Update(category);
            _unitOfWork.Commit();
            return "Category updated successfully.";
        }
        
    }
}
