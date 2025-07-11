
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class ShoppingCartItemsConfiguration : IEntityTypeConfiguration<ShoppingCartItems>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItems> builder)
        {
            builder.HasKey(shoppingCartItems => new {
                shoppingCartItems.StoreId, shoppingCartItems.CustomerId 
               }
            );

            builder.HasData(
                new ShoppingCartItems
                {
                    ItemId = 1,
                    CustomerId = 1,
                    StoreId = 1,
                    UnitId = 1,
                    Quantity = 2,
                    CreatedAt = new DateTime(2025, 7, 11, 10, 0, 0),
                    UpdatedAt = null
                },
                new ShoppingCartItems
                {
                    ItemId = 2,
                    CustomerId = 1,
                    StoreId = 2,
                    UnitId = 1,
                    Quantity = 5,
                    CreatedAt = new DateTime(2025, 7, 10, 9, 30, 0),
                    UpdatedAt = new DateTime(2025, 7, 10, 12, 0, 0)
                },
                new ShoppingCartItems
                {
                    ItemId = 3,
                    CustomerId = 2,
                    StoreId = 2,
                    UnitId = 2,
                    Quantity = 1.5,
                    CreatedAt = new DateTime(2025, 7, 9, 14, 0, 0),
                    UpdatedAt = null
                },
                new ShoppingCartItems
                {
                    ItemId = 4,
                    CustomerId = 3,
                    StoreId = 3,
                    UnitId = 3,
                    Quantity = 10,
                    CreatedAt = new DateTime(2025, 7, 8, 16, 30, 0),
                    UpdatedAt = new DateTime(2025, 7, 9, 8, 0, 0)
                },
                new ShoppingCartItems
                {
                    ItemId = 5,
                    CustomerId = 4,
                    StoreId = 4,
                    UnitId = 4,
                    Quantity = 3,
                    CreatedAt = new DateTime(2025, 7, 7, 11, 15, 0),
                    UpdatedAt = null
                }
            );

            /*
            * ShoppingCartItems -> item
            * One ShoppingCartItems related to One Item.
            * One Item has Many ShoppingCartItems
            */
            builder.HasOne(shoppingCartItems => shoppingCartItems.Item)
            .WithMany(item => item.ShoppingCartItems)
            .HasForeignKey(shoppingCartItems => shoppingCartItems.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * ShoppingCartItems -> Customer (User)
            * One ShoppingCartItems related to One User.
            * One User has Many ShoppingCartItems
            */
            builder.HasOne(shoppingCartItems => shoppingCartItems.Customer)
            .WithMany(customer => customer.ShoppingCartItems)
            .HasForeignKey(shoppingCartItems => shoppingCartItems.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * ShoppingCartItems -> Store 
            * One ShoppingCartItems related to One Store.
            * One Store has Many ShoppingCartItems
            */
            builder.HasOne(shoppingCartItems => shoppingCartItems.Store)
            .WithMany(store => store.ShoppingCartItems)
            .HasForeignKey(shoppingCartItems => shoppingCartItems.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * ShoppingCartItems -> Unit 
            * One ShoppingCartItems related to One Unit.
            * One Unit can be used in Many ShoppingCartItems
            */
            builder.HasOne(shoppingCartItems => shoppingCartItems.Unit)
            .WithMany(unit => unit.ShoppingCartItems)
            .HasForeignKey(shoppingCartItems => shoppingCartItems.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
