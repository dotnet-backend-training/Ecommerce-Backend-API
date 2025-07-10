
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
