

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

            builder.HasData(
             new Invoice
             {
                 Id = 1,
                 CreatedAt = DateTime.UtcNow.AddDays(-10),
                 UpdatedAt = DateTime.UtcNow.AddDays(-5),
                 NetPrice = 150.75,
                 TransactionType = 1,
                 PaymentType = 1,
                 IsPosted = true,
                 IsReviewed = true,
                 IsClosed = false,
                 CustomerId = 1
             },
             new Invoice
             {
                 Id = 2,
                 CreatedAt = DateTime.UtcNow.AddDays(-8),
                 UpdatedAt = DateTime.UtcNow.AddDays(-4),
                 NetPrice = 299.99,
                 TransactionType = 2,
                 PaymentType = 2,
                 IsPosted = false,
                 IsReviewed = false,
                 IsClosed = false,
                 CustomerId = 2
             },
             new Invoice
             {
                 Id = 3,
                 CreatedAt = DateTime.UtcNow.AddDays(-7),
                 UpdatedAt = DateTime.UtcNow.AddDays(-3),
                 NetPrice = 75.50,
                 TransactionType = 1,
                 PaymentType = 1,
                 IsPosted = true,
                 IsReviewed = false,
                 IsClosed = false,
                 CustomerId = 3
             },
             new Invoice
             {
                 Id = 4,
                 CreatedAt = DateTime.UtcNow.AddDays(-6),
                 UpdatedAt = DateTime.UtcNow.AddDays(-2),
                 NetPrice = 450.00,
                 TransactionType = 2,
                 PaymentType = 3,
                 IsPosted = true,
                 IsReviewed = true,
                 IsClosed = true,
                 CustomerId = 4
             },
             new Invoice
             {
                 Id = 5,
                 CreatedAt = DateTime.UtcNow.AddDays(-5),
                 UpdatedAt = DateTime.UtcNow.AddDays(-1),
                 NetPrice = 1200.00,
                 TransactionType = 1,
                 PaymentType = 1,
                 IsPosted = true,
                 IsReviewed = true,
                 IsClosed = false,
                 CustomerId = 5
             }
            );

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
