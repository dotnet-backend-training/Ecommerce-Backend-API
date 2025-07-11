using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend_Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> userManager;

        public AuthRepository(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> RegisterAsync(User user, string password)
        {
            var registerResult = await userManager.CreateAsync(user, password);
            if (registerResult.Succeeded)
            {
                return "User registered successfully";
            }
            var errorMessages = registerResult.Errors.Select(
                 (error) => error.Description
            ).ToList();
            return string.Join(", ", errorMessages);
        }

        public Task<string> LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangePasswordAsync(
            string email,
            string oldPassword,
            string newPassword)
        {
            throw new NotImplementedException();
        }

       
    }
}
