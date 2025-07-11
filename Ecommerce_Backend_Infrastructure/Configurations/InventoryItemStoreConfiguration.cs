
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

            builder.HasData(
             new InventoryItemStore
             {
                 StoreId = 1,
                 ItemId = 1,
                 UserId = 1,
                 Balance = 100,
                 Factor = 1,
                 ReservedQuantity = 10,
                 LastUpdated = DateTime.UtcNow
             },
             new InventoryItemStore
             {
                 StoreId = 1,
                 ItemId = 2,
                 UserId = 2,
                 Balance = 50,
                 Factor = 2,
                 ReservedQuantity = 5,
                 LastUpdated = DateTime.UtcNow
             },
             new InventoryItemStore
             {
                 StoreId = 2,
                 ItemId = 3,
                 UserId = 3,
                 Balance = 75,
                 Factor = 1,
                 ReservedQuantity = 0,
                 LastUpdated = DateTime.UtcNow
             },
             new InventoryItemStore
             {
                 StoreId = 3,
                 ItemId = 4,
                 UserId = 4,
                 Balance = 120,
                 Factor = 3,
                 ReservedQuantity = 15,
                 LastUpdated = DateTime.UtcNow
             },
             new InventoryItemStore
             {
                 StoreId = 3,
                 ItemId = 5,
                 UserId = 5,
                 Balance = 200,
                 Factor = 1,
                 ReservedQuantity = 20,
                 LastUpdated = DateTime.UtcNow
             }
            );
        
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
