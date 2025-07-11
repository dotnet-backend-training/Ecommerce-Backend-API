
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class InventoryItemStoreConfiguration : IEntityTypeConfiguration<InventoryItemStore>
    {
        public void Configure(EntityTypeBuilder<InventoryItemStore> builder)
        {
            builder.HasKey(
                inventoryItemStore => new {
                    inventoryItemStore.StoreId, inventoryItemStore.ItemId 
             });

            /*
             - InventoryItemStore -> Item
                - Each InventoryItemStore is associated with one Item
                - Each Item can have many InventoryItemStore records
            */
            builder.HasOne(inventoryItemStore => inventoryItemStore.Item)
            .WithMany(item => item.InventoryItemStores)
            .HasForeignKey(inventoryItemStore => inventoryItemStore.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

             /*
              - InventoryItemStore -> Store
                - Each InventoryItemStore is associated with one Store
                - Each Store can have many InventoryItemStore records
             */
              builder.HasOne(inventoryItemStore => inventoryItemStore.Store)
             .WithMany(store => store.InventoryItemStores)
             .HasForeignKey(inventoryItemStore => inventoryItemStore.StoreId)
             .OnDelete(DeleteBehavior.Restrict);


            /*
              - InventoryItemStore -> User
               - Each InventoryItemStore is related to One User.
               - Each User can have many InventoryItemStore records
            */
            builder.HasOne(inventoryItemStore => inventoryItemStore.User)
            .WithMany(user => user.InventoryItems)
            .HasForeignKey(inventoryItemStore => inventoryItemStore.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
