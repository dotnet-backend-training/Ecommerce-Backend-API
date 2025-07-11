
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.HasKey(classification => classification.Id);
            
            builder.HasData(
                new Classification { Id = 1, Name = "Electronics & Gadgets" },
                new Classification { Id = 2, Name = "Health & Wellness" },
                new Classification { Id = 3, Name = "Automotive Parts" },
                new Classification { Id = 4, Name = "Sports Equipment" },
                new Classification { Id = 5, Name = "Beauty & Personal Care" }
            );

            // Classification -> User
            builder.HasMany(classification => classification.Users) // Classification assigned to Many User.
            .WithOne(user => user.Classification) // User has One Classification
            .HasForeignKey(classification => classification.Id)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
