using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Core.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public Task<string> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<object>> RegisterAsync(User user, string password)
        {
            var normalizedEmail = user.Email?.ToUpperInvariant();
            var normalizedUserName = user.UserName?.ToUpperInvariant();
            var existingUser = await userManager.Users.FirstOrDefaultAsync(dbUser =>
                (normalizedEmail != null && dbUser.NormalizedEmail == normalizedEmail) ||
                (normalizedUserName != null && dbUser.NormalizedUserName == normalizedUserName)
            );
            if (existingUser is not null)
            {
                return ApiResponse<object>.FailResponse(
                   message: "Registration failed",
                   error: "An account with this email address or Username already exists.",
                   statusCode: HttpStatusCode.Conflict
                );
            }
            var registerResult = await userManager.CreateAsync(user, password);
            if (registerResult.Succeeded)
            {
                return ApiResponse<object>.SuccessResponse(
                  message: "User registered successfully",
                  statusCode: HttpStatusCode.Created
                );
            }
            var errorMessages = registerResult.Errors.Select(
                 (error) => error.Description
            ).ToList();
            return ApiResponse<object>.FailResponse(
               message: "Registration failed",
               errors: errorMessages,
               statusCode: HttpStatusCode.InternalServerError
            );
        }


       
    }
}
