using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);

            builder.HasData(
             new Item
             {
                 Id = 1,
                 Name = "iPhone 14",
                 Description = "Latest Apple smartphone",
                 Price = 999.99,
                 MainGroupId = 1,
                 SubGroupId = 1,
                 SubGroup2Id = 1,
             },
             new Item
             {
                 Id = 2,
                 Name = "Dell XPS 15",
                 Description = "High performance laptop",
                 Price = 1500,
                 MainGroupId = 1,
                 SubGroupId = 2,
                 SubGroup2Id = 2
             },
             new Item
             {
                 Id = 3,
                 Name = "Men's Casual Shirt",
                 Description = "Comfortable cotton shirt",
                 Price = 35.50,
                 MainGroupId = 2,
                 SubGroupId = 3,
                 SubGroup2Id = 3
             },
             new Item
             {
                 Id = 4,
                 Name = "Women's Summer Dress",
                 Description = "Light and breezy",
                 Price = 45.99,
                 MainGroupId = 2,
                 SubGroupId = 4,
                 SubGroup2Id = 4
             },
             new Item
             {
                 Id = 5,
                 Name = "Samsung Galaxy S22",
                 Description = "Flagship Samsung phone",
                 Price = 850,
                 MainGroupId = 1,
                 SubGroupId = 1,
                 SubGroup2Id = 1
             }
            );

            /*
             * Item -> InventoryItemStores (Join table btw store and item)
             * One Item can have many InventoryItemStore.
             * One InventoryItemStore realted to One Item.
             */
            builder.HasMany(item => item.InventoryItemStores)
            .WithOne(inventoryItemStore => inventoryItemStore.Item)
            .HasForeignKey(inventoryItemStore => inventoryItemStore.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * Item -> ItemUnit (Join table btw item and unit)
            *  One Item can have many ItemUnit records.
            * ItemUnit related to one Item.
            */
            builder.HasMany(item => item.ItemUnits)
            .WithOne(itemUnit => itemUnit.Item)
            .HasForeignKey(itemUnit => itemUnit.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * Item -> InvoiceDetails
            *  One Item can have many InvoiceDetails records.
            * InvoiceDetails related to one Item.
            */
            builder.HasMany(item => item.InvoiceDetails)
            .WithOne(invoiceDetails => invoiceDetails.Item)
            .HasForeignKey(invoiceDetails => invoiceDetails.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Item -> MainGroup
            *  One Item belong to One MainGroup.
            *  MainGroup Contains Many items.
            */
            builder.HasOne(item => item.MainGroup)
            .WithMany(mainGroup => mainGroup.Items)
            .HasForeignKey(item => item.MainGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Item -> SubGroup
            *  One Item belong to One SubGroup.
            *  SubGroup Contains Many items.
            */
            builder.HasOne(item => item.SubGroup)
            .WithMany(subGroup => subGroup.Items)
            .HasForeignKey(item => item.SubGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Item -> SubGroup2
            *  One Item belong to One SubGroup2.
            *  SubGroup2 Contains Many items.
            */
            builder.HasOne(item => item.SubGroup2)
            .WithMany(subGroup2 => subGroup2.Items)
            .HasForeignKey(item => item.SubGroup2Id)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
