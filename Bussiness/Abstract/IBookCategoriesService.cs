using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities.Concrete;
using System.Collections.Generic;

namespace Bussiness.Abstract
{
    public interface IBookCategoriesService
    {
        bool Add(Categories category);
        bool Update(Categories category);
        bool Delete(int id);
        Categories GetById(int id);
        List<Categories> GetAll();
    }
}
