using Azure.Core;
using Ecommerce_Backend_Core.DTO_s;
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

namespace Ecommerce_Backend_Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
        }
        private string GenerateToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!)
            );
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(30)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApiResponse> RegisterAsync(User user, string password)
        {
            var normalizedEmail = user.Email?.ToUpperInvariant();
            var normalizedUserName = user.UserName?.ToUpperInvariant();
            var existingUser = await _userManager.Users.FirstOrDefaultAsync(dbUser =>
                (normalizedEmail != null && dbUser.NormalizedEmail == normalizedEmail) ||
                (normalizedUserName != null && dbUser.NormalizedUserName == normalizedUserName)
            );
            if (existingUser is not null)
            {
                return FailResponse.CreateWithError(
                   message: "Registration failed",
                   error: "An account with this email address or Username already exists.",
                   statusCode: HttpStatusCode.Conflict
                );
            }
            var registerResult = await _userManager.CreateAsync(user, password);
            if (registerResult.Succeeded)
            {
                return new SuccessResponse(
                  message: "User registered successfully",
                  statusCode: HttpStatusCode.Created
                );
            }
            var errorMessages = registerResult.Errors.Select(
                error => error.Description   
             ).ToList();
            return FailResponse.CreateWithErrors(
               message: "Registration failed",
               errors: errorMessages,
               statusCode: HttpStatusCode.InternalServerError
            );
        }
       
        public async Task<ApiResponse> LoginAsync(
            string userName,
            string password
            )
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user is null)
            {
                return FailResponse.CreateWithError(
                    statusCode: HttpStatusCode.BadRequest,
                    message: "Failed to login.",
                    error: "Invalid credentials. Please verify your login information and try again."
                 );
            }
            var result = await _signInManager.PasswordSignInAsync(
                user,
                password,
                isPersistent: false,
                lockoutOnFailure: false
            );
            if (!result.Succeeded)
            {
                return FailResponse.CreateWithError(
                statusCode: HttpStatusCode.BadRequest,
                message: "Failed to login.",
                error: "Invalid credentials. Please verify your login information and try again."
                );
            }
            return new SuccessResponse<LoginResponseDto>(
                statusCode: HttpStatusCode.OK,
                message: "User login successfully",
                data: new LoginResponseDto{
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
