using Entity.Entities;
using Entity.Identity;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task<CustomerViewModel> FindByUserNameAsync(string name);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<CustomerViewModel>> GetAllUsers();
        Task<List<RoleViewModel>> GetAllRoles();

        Task SignOutAsync();
        Task<object> FindCustomerByNameAsync(LoginViewModel model);
        Task UpdateAsync(AppUser user);
    }
}
