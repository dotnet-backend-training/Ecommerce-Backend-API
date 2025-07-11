
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class SubGroupConfiguration : IEntityTypeConfiguration<SubGroup>
    {
        public void Configure(EntityTypeBuilder<SubGroup> builder)
        {
            builder.HasKey(subGroup => subGroup.Id);

            /*
            * SubGroup -> Items.
            * SubGroup has Many Items.
            * Item belong to One SubGroup.
            */
            builder.HasMany(subGroup => subGroup.Items)
            .WithOne(item => item.SubGroup)
            .HasForeignKey(item => item.SubGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * SubGroup -> SubGroups2.
            * SubGroup has Many SubGroups2.
            * SubGroup2 belong to One SubGroup.
            */
            builder.HasMany(subGroup => subGroup.SubGroups2)
            .WithOne(subGroup2 => subGroup2.SubGroup)
            .HasForeignKey(subGroup2 => subGroup2.SubGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * SubGroup -> MainGroup.
            * SubGroup belong to one MainGroup.
            * MainGroup has many SubGroup
            */
            builder.HasOne(subGroup => subGroup.MainGroup)
            .WithMany(mainGroup => mainGroup.SubGroups)
            .HasForeignKey(subGroup => subGroup.MainGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
