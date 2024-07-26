using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Bussiness.Abstract
{
    public interface IUsersBooksService
    {
        bool Add(UsersBooks usersBooks);
        bool Update(UsersBooksUpdateDto usersBooksUpdateDto);
        bool Delete(int id);
        UsersBooks GetById(int id);
        List<UsersBooks> GetAll();
    }
}
