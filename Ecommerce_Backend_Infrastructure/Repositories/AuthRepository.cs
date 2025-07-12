using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Core.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ApiResponse<object>> RegisterAsync(User user, string password)
        {
            var existingUser = await userManager.Users.FirstOrDefaultAsync(
                dbUser => 
                string.Equals(dbUser.Email, user.Email, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(dbUser.UserName, user.UserName, StringComparison.OrdinalIgnoreCase)
             );
            if(existingUser is not null)
            {
                return ApiResponse<object>.FailResponse(
                   message: "Registration failed",
                   error: "An account with this email address or Username already exists."
                );
            }
            var registerResult = await userManager.CreateAsync(user, password);
            if (registerResult.Succeeded)
            {
                return ApiResponse<object>.SuccessResponse(
                  message: "User registered successfully"
                );
            }
            var errorMessages = registerResult.Errors.Select(
                 (error) => error.Description
            ).ToList();
            return ApiResponse<object>.FailResponse(
               message: "Registration failed",
               error: "An account with this email address already exists."
            );
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
