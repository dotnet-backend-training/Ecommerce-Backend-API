
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class InvoiceDetailsConfiguration : IEntityTypeConfiguration<InvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
        {
            builder.HasKey(
                invoiceDetails => new { 
                    invoiceDetails.InvoiceId, invoiceDetails.ItemId 
                }
            );

            builder.HasData(
               new InvoiceDetails
               {
                   InvoiceId = 1,
                   ItemId = 1,
                   UnitId = 1,
                   Price = 30,
                   Quantity = 2,
                   Factor = 1.0,
                   CreatedAt = DateTime.UtcNow.AddDays(-10)
               },
               new InvoiceDetails
               {
                   InvoiceId = 1,
                   ItemId = 2,
                   UnitId = 2,
                   Price = 20,
                   Quantity = 1,
                   Factor = 1.0,
                   CreatedAt = DateTime.UtcNow.AddDays(-10)
               },
               new InvoiceDetails
               {
                   InvoiceId = 2,
                   ItemId = 3,
                   UnitId = 1,
                   Price = 15,
                   Quantity = 3,
                   Factor = 1.0,
                   CreatedAt = DateTime.UtcNow.AddDays(-8)
               },
               new InvoiceDetails
               {
                   InvoiceId = 3,
                   ItemId = 4,
                   UnitId = 3,
                   Price = 50,
                   Quantity = 1,
                   Factor = 1.0,
                   CreatedAt = DateTime.UtcNow.AddDays(-7)
               },
               new InvoiceDetails
               {
                   InvoiceId = 5,
                   ItemId = 5,
                   UnitId = 1,
                   Price = 100,
                   Quantity = 5,
                   Factor = 1.0,
                   CreatedAt = DateTime.UtcNow.AddDays(-5)
               }
            );

            /*
             * InvoiceDetails -> Invoice
                * Each InvoiceDetails belongs to exactly one Invoice
                * One Invoice can have many InvoiceDetails.
             */
            builder.HasOne(invoiceDetails => invoiceDetails.Invoice)
            .WithMany(invoice => invoice.InvoiceDetails)
            .HasForeignKey(invoice => invoice.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * InvoiceDetails -> Item
               * Each InvoiceDetails belongs to exactly one Item
               * One Item can have many InvoiceDetails.
            */
           builder.HasOne(invoiceDetails => invoiceDetails.Item)
          .WithMany(item => item.InvoiceDetails)
          .HasForeignKey(invoiceDetails => invoiceDetails.ItemId)
          .OnDelete(DeleteBehavior.Restrict);

            /*
              * InvoiceDetails -> Unit
                 * Each InvoiceDetails record belongs to one Unit
                 * A single Unit can be associated with many InvoiceDetails.
            */
            builder.HasOne(invoiceDetails => invoiceDetails.Unit)
            .WithMany(unit => unit.InvoiceDetails)
            .HasForeignKey(invoiceDetails => invoiceDetails.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
