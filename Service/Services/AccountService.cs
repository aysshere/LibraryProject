using AutoMapper;
using DataAccess.Context;
using Entity.Identity;
using Entity.Entities;
using Entity.Interfaces;
using Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Extensions;
using System.Collections.Generic;
using System.Linq;
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
            var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
            if (!roleExists)
            {
                var role = _mapper.Map<AppRole>(model);
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return "Role created successfully.";
                }
                return string.Join(", ", result.Errors.Select(e => e.Description));
            }
            return "This role already exists.";
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
            if (user == null) return "User not found!";

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
            {
                Session.SetJson("user", user);  // Store the AppUser in the session
                return "OK";
            }
            return "Login failed!";
        }

        public async Task<CustomerViewModel> FindByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<CustomerViewModel>(user);
        }

        public async Task<object> FindCustomerByNameAsync(LoginViewModel model)
        {
            var appUser = await _userManager.FindByNameAsync(model.UserName);
            if (appUser == null) return null;

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (!passwordCheck.Succeeded) return null;

            return appUser;
        }

        public async Task<AppUser> FindUserByNameAsync(LoginViewModel model)
        {
            var appUser = await _userManager.FindByNameAsync(model.UserName);
            if (appUser == null) return null;

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (!passwordCheck.Succeeded) return null;

            return appUser;
        }

        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<List<RoleViewModel>>(roles);
        }

        public async Task<List<CustomerViewModel>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<CustomerViewModel>>(users);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task UpdateAsync(AppUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.UserName = user.UserName;
                

                var result = await _userManager.UpdateAsync(existingUser);
                if (!result.Succeeded)
                {
                    throw new ApplicationException("Update failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                throw new ApplicationException("User not found.");
            }
        }
    }
}
