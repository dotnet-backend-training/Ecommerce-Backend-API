using Azure.Core;
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Core.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend_Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;

        public AuthRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        private string GenerateToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:Key"])
            );
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(30)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
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
       
        public async Task<ApiResponse<object>> LoginAsync(
            string userName,
            string password
            )
        {
            var user = await userManager.FindByNameAsync(userName);
            if(user is null)
            {
                return ApiResponse<object>.FailResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    message: "Failed to login.",
                    error: "Invalid username or password"
                 );
            }
            var result = await signInManager.PasswordSignInAsync(
                user,
                password,
                isPersistent: false,
                lockoutOnFailure: false
            );
            if (!result.Succeeded)
            {
                return ApiResponse<object>.FailResponse(
                statusCode: HttpStatusCode.InternalServerError,
                message: "Failed to login.",
                error: "Unexpected error occurred while login"
             );
            }
            return ApiResponse<object>.SuccessResponse(
                statusCode: HttpStatusCode.OK,
                message: "User login successfully",
                data: new {
                AccessToken= GenerateToken(user),
                }
            );
        }
        public Task<string> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

     
    }
}
