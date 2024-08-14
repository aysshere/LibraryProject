using AutoMapper;
using DataAccess.Context;
using DataAccess.Identity;
using Entity.Entities;
using Entity.Interfaces;
using Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly LibraryProjectDb _context;
        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, LibraryProjectDb context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }


        public async Task<string> CreateRoleAsync(RoleViewModel model)
        {
            string message = string.Empty;
            var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
            if (!roleExists)
            {
                var role = new AppRole()
                {
                    Name = model.RoleName,
                    Description = model.Description // Assuming AppRole has a Description property
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    message = "Rol başarıyla oluşturuldu.";
                }
                else
                {
                    message = string.Join(", ", result.Errors.Select(e => e.Description));
                }
            }
            else
            {
                message = "Böyle bir rol mevcut.";
            }
            return message;
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
                var customCustomer = new Customer
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,                   
                    PasswordHash = user.PasswordHash // Store hashed password or manage it as per your requirements
                };

                _context.Customers.Add(customCustomer);
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

        public async Task<CustomerViewModel> FindByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<CustomerViewModel>(user);
        }

        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            var roleViewModels = _mapper.Map<List<RoleViewModel>>(roles);
            return roleViewModels;
        }

        public async Task<List<CustomerViewModel>> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = _mapper.Map<List<CustomerViewModel>>(users);
            return userViewModels;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
