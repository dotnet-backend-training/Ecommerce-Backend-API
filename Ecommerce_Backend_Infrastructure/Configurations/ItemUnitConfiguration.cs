
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class ItemUnitConfiguration : IEntityTypeConfiguration<ItemUnit>
    {
        public void Configure(EntityTypeBuilder<ItemUnit> builder)
        {
            builder.HasKey(
                itemUnit => new {
                    itemUnit.ItemId, itemUnit.UnitId 
                }
            );

            builder.HasData(
               new ItemUnit { ItemId = 1, UnitId = 1, Factor = 1 },  // iPhone 14 - Piece
               new ItemUnit { ItemId = 2, UnitId = 1, Factor = 1 },  // Dell XPS 15 - Piece
               new ItemUnit { ItemId = 3, UnitId = 1, Factor = 1 },  // Men's Casual Shirt - Piece
               new ItemUnit { ItemId = 4, UnitId = 1, Factor = 1 },  // Women's Summer Dress - Piece
               new ItemUnit { ItemId = 5, UnitId = 1, Factor = 1 }   // Samsung Galaxy S22 - Piece
            );

            /*
            * ItemUnit -> item  (Join table btw unit and item)
            * One ItemUnit related to one Item.
            * One Item has Many ItemUnit.
            */
            builder.HasOne(itemUnit => itemUnit.Item)
            .WithMany(item => item.ItemUnits)
            .HasForeignKey(itemUnit => itemUnit.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * ItemUnit -> Unit  (Join table btw unit and item)
            * One ItemUnit related to one Unit.
            * One Unit has Many ItemUnit.
            */
            builder.HasOne(itemUnit => itemUnit.Unit)
            .WithMany(unit => unit.ItemUnits)
            .HasForeignKey(itemUnit => itemUnit.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
