using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IGenericRepository<T>where T : class,new()
    {
        List<T> GetAll();
        T GetbyId(int id);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
