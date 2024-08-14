using Entity.Entities;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ICategoryService
    {
        Task<string> AddCategoryAsync(CategoryViewModel model);

        Task<string> UpdateCategoryAsync(CategoryViewModel model);

        Task<string> DeleteCategoryAsync(int categoryId);

        Task<CategoryViewModel> GetCategoryByIdAsync(int categoryId);

        Task<List<CategoryViewModel>> GetAllCategoriesAsync();

        

        
        
    }
}
