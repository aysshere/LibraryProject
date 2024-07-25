using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities.Concrete;
using System.Collections.Generic;

namespace Bussiness.Abstract
{
    public interface IUsersBooksService
    {
        bool Add(UsersBooks usersBooks);
        bool Update(UsersBooks usersBooks);
        bool Delete(int id);
        UsersBooks GetById(int id);
        List<UsersBooks> GetAll();
    }
}
