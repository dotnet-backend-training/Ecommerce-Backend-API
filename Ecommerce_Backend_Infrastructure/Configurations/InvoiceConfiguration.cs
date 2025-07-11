

using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(invoice => invoice.Id);

            /*
             - Invoice -> User
                - Each Invoice is associated with one Customer.
                - A Customer can has Many Invoices.
            */
            builder.HasOne(invoice => invoice.Customer)
            .WithMany(user => user.Invoices)
            .HasForeignKey(invoice => invoice.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
               - Invoice -> InvoiceDetails
                  - Each Invoice has Many InvoiceDetails.
                  - An InvoiceDetails belong to One Invoice
            */
            builder.HasMany(invoice => invoice.InvoiceDetails)
            .WithOne(invoiceDetails => invoiceDetails.Invoice)
            .HasForeignKey(invoiceDetails => invoiceDetails.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
