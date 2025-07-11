
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class SubGroup2Configuration : IEntityTypeConfiguration<SubGroup2>
    {
        public void Configure(EntityTypeBuilder<SubGroup2> builder)
        {
            builder.HasKey(subGroup2 => subGroup2.Id);

            builder.HasData(
                new SubGroup2 { Id = 1, MainGroupId = 1, Name = "Smartphones", SubGroupId = 1 },
                new SubGroup2 { Id = 2, MainGroupId = 2, Name = "Gaming Laptops", SubGroupId = 2 },
                new SubGroup2 { Id = 3, MainGroupId = 3, Name = "Shirts", SubGroupId = 3 },
                new SubGroup2 { Id = 4, MainGroupId = 3, Name = "Dresses", SubGroupId = 4 },
                new SubGroup2 { Id = 5, MainGroupId = 1, Name = "Blenders", SubGroupId = 5 }
            );

            /*
            * SubGroup2 -> Items.
            * SubGroup2 has Many Items.
            * Item belong to One SubGroup2.
            */
            builder.HasMany(subGroup2 => subGroup2.Items)
            .WithOne(item => item.SubGroup2)
            .HasForeignKey(item => item.SubGroup2Id)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * SubGroup2 -> MainGroup.
            * SubGroup2 belong to One MainGroup.
            * MainGroup can have Many SubGroup2s
            */
            builder.HasOne(subGroup2 => subGroup2.MainGroup)
            .WithMany(mainGroup => mainGroup.SubGroups2)
            .HasForeignKey(subGroup2 => subGroup2.MainGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * SubGroup2 -> SubGroup.
            * SubGroup2 belong to One SubGroup.
            * SubGroup can have Many SubGroup2s
            */
            builder.HasOne(subGroup2 => subGroup2.SubGroup)
            .WithMany(subGroup => subGroup.SubGroups2)
            .HasForeignKey(subGroup2 => subGroup2.SubGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
