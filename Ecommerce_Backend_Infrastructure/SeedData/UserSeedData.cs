
using Ecommerce_Backend_Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Backend_Infrastructure.SeedData
{
    public static class UserSeedData
    {
        public static User[] GetUsers()
        {
            var hasher = new PasswordHasher<User>();

            var users = new[]
            {
                new User
                {
                    Id = 1,
                    UserName = "userone",
                    NormalizedUserName = "USERONE",
                    Email = "userone@example.com",
                    NormalizedEmail = "USERONE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = System.Guid.NewGuid().ToString(),
                    GovernmentId = 1,
                    CityId = 1,
                    ZoneId = 1,
                    ClassificationId = 1
                },
                new User
                {
                    Id = 2,
                    UserName = "usertwo",
                    NormalizedUserName = "USERTWO",
                    Email = "usertwo@example.com",
                    NormalizedEmail = "USERTWO@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = System.Guid.NewGuid().ToString(),
                    GovernmentId = 1,
                    CityId = 2,
                    ZoneId = 2,
                    ClassificationId = 1
                },
                new User
                {
                    Id = 3,
                    UserName = "userthree",
                    NormalizedUserName = "USERTHREE",
                    Email = "userthree@example.com",
                    NormalizedEmail = "USERTHREE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = System.Guid.NewGuid().ToString(),
                    GovernmentId = 2,
                    CityId = 3,
                    ZoneId = 3,
                    ClassificationId = 2
                },
                new User
                {
                    Id = 4,
                    UserName = "userfour",
                    NormalizedUserName = "USERFOUR",
                    Email = "userfour@example.com",
                    NormalizedEmail = "USERFOUR@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = System.Guid.NewGuid().ToString(),
                    GovernmentId = 2,
                    CityId = 4,
                    ZoneId = 4,
                    ClassificationId = 2
                },
                new User
                {
                    Id = 5,
                    UserName = "userfive",
                    NormalizedUserName = "USERFIVE",
                    Email = "userfive@example.com",
                    NormalizedEmail = "USERFIVE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = System.Guid.NewGuid().ToString(),
                    GovernmentId = 3,
                    CityId = 5,
                    ZoneId = 5,
                    ClassificationId = 3
                }
            };

            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, "Password123!");
            }
            return users;
        }
    }
}
