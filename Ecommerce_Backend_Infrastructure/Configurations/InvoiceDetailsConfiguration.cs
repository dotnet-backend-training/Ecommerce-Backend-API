
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
