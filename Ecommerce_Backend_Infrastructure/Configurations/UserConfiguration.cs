
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(UserSeedData.GetUsers());
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
