using AutoMapper;
using Bussiness.Abstract;

using DataAccess.Context;
using DataAccess.Identity;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly LibraryProjectContext _context;

        public AccountManager(LibraryProjectContext context)
        {
            _context = context;
        }




        public async Task<string> CreateUserAsync(RegisterViewModel model)
        {
            string message = string.Empty;
            AppUser user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
                
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {
                // Synchronize data with the Users table
                var customUser = new Users
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    
                    PasswordHash = user.PasswordHash // Store hashed password or manage it as per your requirements
                };

                _context.USERS.Add(customUser);
                await _context.SaveChangesAsync();

                message = "OK";
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    message = error.Description;
                }
            }
            return message;
        }


        public async Task<string> FindByNameAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return "Kullanıcı bulunamadı!";
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
            {
                return "OK";
            }
            return "Giriş başarısız!";
        }

        public async Task<Users> FindByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<Users>(user);
        }

        

        public async Task<List<Users>> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = _mapper.Map<List<Users>>(users);
            return userViewModels;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
