
using Ecommerce_Backend_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Create a password hasher instance to hash passwords for seeding
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
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
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
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
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
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
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
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
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
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                    SecurityStamp = System.Guid.NewGuid().ToString(),
                    GovernmentId = 3,
                    CityId = 5,
                    ZoneId = 5,
                    ClassificationId = 3
                }
            };

            builder.HasData(users);
            /*
            * User -> CustomerStores (Join table btw user and store)
            * One User can be linked to many CustomerStores.
            * Each CustomerStore is associated with one User.
            */
            builder.HasMany(user => user.CustomerStores)
            .WithOne(customerStore => customerStore.Customer)
            .HasForeignKey(customer => customer.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * User -> InventoryItems (Join table btw item and store)
            * One User can be related to many InventoryItemStore records.
            * One InventoryItemStore is linked to one User.
            */
            builder.HasMany(user => user.InventoryItems)
            .WithOne(inventoryItemStore => inventoryItemStore.User)
            .HasForeignKey(inventoryItemStore => inventoryItemStore.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * User -> Invoice
            * One User can create many Invoices.
            * Each Invoice is created by one User.
            */
            builder.HasMany(user => user.Invoices)
            .WithOne(invoice => invoice.Customer)
            .HasForeignKey(invoice => invoice.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * User -> ShoppingCartItems
            * One User can have many ShoppingCartItems.
            * Each ShoppingCartItem is linked to one User.
            */
            builder.HasMany(user => user.ShoppingCartItems)
            .WithOne(shoppingCartItem => shoppingCartItem.Customer)
            .HasForeignKey(shoppingCartItem => shoppingCartItem.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * User -> Government
            * Each User belongs to one Government.
            * One Government can have many Users.
            */
            builder.HasOne(user => user.Government)
            .WithMany(government => government.Users)
            .HasForeignKey(user => user.GovernmentId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * User -> City
            * Each User belongs to one City.
            * One City can have many Users.
            */
            builder.HasOne(user => user.City)
            .WithMany(city => city.Users)
            .HasForeignKey(user => user.CityId)
            .OnDelete(DeleteBehavior.Restrict);


            /*
            * User -> Zone
            * Each User belongs to one Zone.
            * One Zone can have many Users.
            */
             builder.HasOne(user => user.Zone)
            .WithMany(zone => zone.Users)
            .HasForeignKey(user => user.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * User -> Classification
            * Each User can have one Classification.
            * One Classification can have many Users.
            */
            builder.HasOne(user => user.Classification)
            .WithMany(classification => classification.Users)
            .HasForeignKey(user => user.ClassificationId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
