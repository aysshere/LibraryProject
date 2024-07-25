using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities.Concrete;
using System.Collections.Generic;


namespace Bussiness.Abstract
{
    public interface IUsersService
    {
        bool Add(Users user);
        bool Update(Users user);
        bool Delete(int id);
        Users GetById(int id);
        List<Users> GetAll();
    }
}
