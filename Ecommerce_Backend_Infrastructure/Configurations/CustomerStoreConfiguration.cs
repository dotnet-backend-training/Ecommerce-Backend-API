
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    internal class CustomerStoreConfiguration : IEntityTypeConfiguration<CustomerStore>
    {
        public void Configure(EntityTypeBuilder<CustomerStore> builder)
        {
            builder.HasKey(
                customerStore => new {
                    customerStore.CustomerId,
                    customerStore.StoreId,
                }
            );

            // CustomerStore -> Customer
            builder.HasOne(customerStore => customerStore.Customer) //  Each CustomerStore references one Customer (User)
            .WithMany(customer => customer.CustomerStores) // Each User can be associated with many CustomerStores
            .HasForeignKey(customerStore => customerStore.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            // CustomerStore -> Store
            builder.HasOne(customerStore => customerStore.Store) // Each CustomerStore references one Store.
            .WithMany(store => store.CustomerStores) // A Store can be associated with many CustomerStore entries.
            .HasForeignKey(customerStore => customerStore.StoreId)
            .OnDelete(DeleteBehavior.Restrict);
            }
    }
}
