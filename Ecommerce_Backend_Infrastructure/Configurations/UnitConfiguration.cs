
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(unit => unit.Id);

            builder.HasData(
               new Unit { Id = 1, Name = "Piece" },
               new Unit { Id = 2, Name = "Kilogram" },
               new Unit { Id = 3, Name = "Liter" },
               new Unit { Id = 4, Name = "Box" },
               new Unit { Id = 5, Name = "Pack" }
           );

            /*
            * Unit -> ItemUnits.
            * One Unit can be used in Many ItemUnits.
            * One ItemUnit is related to One Unit.
            */
            builder.HasMany(unit => unit.ItemUnits)
            .WithOne(itemUnit => itemUnit.Unit)
            .HasForeignKey(itemUnit => itemUnit.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Unit -> InvoiceDetails.
            * One Unit can be used in Many InvoiceDetails.
            * One InvoiceDetail uses One Unit.
            */
            builder.HasMany(unit => unit.InvoiceDetails)
            .WithOne(invoiceDetails => invoiceDetails.Unit)
            .HasForeignKey(invoiceDetails => invoiceDetails.UnitId)
            .OnDelete(DeleteBehavior.Restrict);


            /*
            * Unit -> ShoppingCartItem.
            * One Unit can be used in Many ShoppingCartItem.
            * One ShoppingCartItem uses One Unit.
            */
            builder.HasMany(unit => unit.ShoppingCartItems)
            .WithOne(shoppingCartItem => shoppingCartItem.Unit)
            .HasForeignKey(shoppingCartItem => shoppingCartItem.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
