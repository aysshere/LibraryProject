using AutoMapper;
using DataAccess.Context;
using DataAccess.Identity;
using Entity.Entities;
using Entity.Interfaces;
using Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Extensions;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, LibraryProjectDb context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;
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

                // Now customCustomer.Id should have the correct value

                // Store the customer in the session
                Session.SetJson("user", customCustomer);

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
                // Find and map the customer from AppUser
                var customer = await FindCustomerByNameAsync(model);
                if (customer != null)
                {
                    // Store the customer in the session
                    Session.SetJson("user", customer);
                }

                return "OK";
            }
            return "Giriş başarısız!";
        }


        public async Task<CustomerViewModel> FindByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<CustomerViewModel>(user);
        }

        public async Task<Customer> FindCustomerByNameAsync(LoginViewModel model)
        {
            // Attempt to find the user by their username (or email, depending on your setup)
            var appUser = await _userManager.FindByNameAsync(model.UserName);

            if (appUser == null)
            {
                return null; // No user found with the provided username
            }

            // Check if the password is correct
            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);

            if (!passwordCheck.Succeeded)
            {
                return null; // Invalid password
            }

            // Map the AppUser to your Customer entity (assuming you have such mapping logic)
            var customer = new Customer
            {
                Id = appUser.Id, // Assuming AppUser and Customer have corresponding Id fields
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                PhoneNumber = appUser.PhoneNumber,
                UserName = appUser.UserName,
                Gender = appUser.Gender,
                PasswordHash = appUser.PasswordHash,
                Status = appUser.Status,
            };

            return customer;
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

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);      //Verilen nesneyi ara katmanda günceller.
            _context.SaveChanges();
        }
    }
}
