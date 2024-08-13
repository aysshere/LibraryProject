using DataAccess.Context;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryProjectDb _context;
        private readonly DbSet<T> _dbSet;

        public Repository(LibraryProjectDb context)  //UnitOfWork
        {
            _context = context;         //ara katman - veritabanı
            _dbSet = _context.Set<T>(); //tablo
        }
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            //_context.SaveChanges();       //UnitofWork tarafından yapılacak.
            //_context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            //_context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            //_context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity.GetType().GetProperty("IsDeleted") != null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);  //tabloda ISDeleted kullanıyorsak
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
            //_context.SaveChanges();
        }
        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            foreach (var tablo in includes)
            {
                query = query.Include(tablo);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();  //AsNoTracking() -> EF Core verileri takip etmiyor (modified, deleted gibi). 
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
