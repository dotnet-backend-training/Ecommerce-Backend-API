
using Ecommerce_Backend_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend_Infrastructure.Data
{
    public class AppDbContext: IdentityDbContext<User, IdentityRole<int>,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ItemUnit>()
                .HasKey(itemUnit => new { itemUnit.ItemId, itemUnit.UnitId });

            builder.Entity<CustomerStore>().
                HasKey(customerStore => new { customerStore.StoreId, customerStore.CustomerId });

            builder.Entity<InventoryItemStore>().
                HasKey(inventoryItemStore => new { inventoryItemStore.StoreId, inventoryItemStore.ItemId });

            builder.Entity<ShoppingCartItems>().
                HasKey(shoppingCartItems => new { shoppingCartItems.StoreId, shoppingCartItems.CustomerId });

            builder.Entity<InvoiceDetails>()
                .HasKey(invoiceDetails => new {invoiceDetails.InvoiceId, invoiceDetails.ItemId });
        }
    } 
}
