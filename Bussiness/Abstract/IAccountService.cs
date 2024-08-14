using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task<Users> FindByUserNameAsync(string name);
        Task<List<Users>> GetAllUsers();
        Task SignOutAsync();

    }
}
