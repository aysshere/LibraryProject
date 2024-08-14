using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bussiness.Concrete
{
    public class UsersManager : IUsersService
    {
        public bool Add(Users user)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    context.USERS.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }

            return true;
        }

        public bool Update(Users user)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    var existingUser = context.USERS.FirstOrDefault(u => u.Id == user.Id);
                    if (existingUser == null)
                    {
                        throw new KeyNotFoundException("User not found.");
                    }

                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Email = user.Email;
                    existingUser.PhoneNumber = user.PhoneNumber;
                    existingUser.UserName = user.UserName;
                    existingUser.Gender = user.Gender;
                    existingUser.PasswordHash = user.PasswordHash;
                    existingUser.Status = user.Status;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the user.", ex);
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (var context = new LibraryProjectContext())
                {
                    var user = context.USERS.FirstOrDefault(u => u.Id == id);
                    if (user == null)
                    {
                        throw new KeyNotFoundException("User not found.");
                    }

                    context.USERS.Remove(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the user.", ex);
            }

            return true;
        }

        public Users GetById(int id)
        {
            using (var context = new LibraryProjectContext())
            {
                var user = context.USERS.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                return user;
            }
        }

        public List<Users> GetAll()
        {
            using (var context = new LibraryProjectContext())
            {
                return context.USERS.ToList();
            }
        }
    }
}
