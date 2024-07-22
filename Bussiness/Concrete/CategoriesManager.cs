using Bussiness.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bussiness.Concrete
{
    public class CategoriesManager : IBookCategoriesService
    {
        public bool Add(Categories category)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    context.CATEGORIES.Add(category);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }

            return true;
        }

        public bool Update(Categories category)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    var existingCategory = context.CATEGORIES.FirstOrDefault(c => c.Id == category.Id);
                    if (existingCategory != null)
                    {
                        existingCategory.Name = category.Name;
                        context.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    var category = context.CATEGORIES.FirstOrDefault(c => c.Id == id);
                    if (category != null)
                    {
                        context.CATEGORIES.Remove(category);
                        context.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }

            return true;
        }

        public Categories GetById(int id)
        {
            using (var context = new LibraryProjectContext())
            {
                return context.CATEGORIES.FirstOrDefault(c => c.Id == id);
            }
        }

        public List<Categories> GetAll()
        {
            using (var context = new LibraryProjectContext())
            {
                return context.CATEGORIES.ToList();
            }
        }
    }
}
