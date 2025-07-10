
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
