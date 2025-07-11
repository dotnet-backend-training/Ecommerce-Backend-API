﻿
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class MainGroupConfiguration : IEntityTypeConfiguration<MainGroup>
    {
        public void Configure(EntityTypeBuilder<MainGroup> builder)
        {
            builder.HasKey(mainGroup =>  mainGroup.Id);

            /*
            * MainGroup -> item
            * One MainGroup has Many items.
            * One Item related to One mainGroup.
            */
            builder.HasMany(mainGroup => mainGroup.Items)
            .WithOne(item => item.MainGroup)
            .HasForeignKey(item => item.MainGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * MainGroup -> SubGroup
            * One MainGroup has Many SubGroups.
            * One SubGroup related to One mainGroup.
            */
            builder.HasMany(mainGroup => mainGroup.SubGroups)
            .WithOne(subGroup => subGroup.MainGroup)
            .HasForeignKey(subGroup => subGroup.MainGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * MainGroup -> SubGroup2
            * One MainGroup has Many SubGroup2s.
            * One SubGroup2 related to One mainGroup.
            */
            builder.HasMany(mainGroup => mainGroup.SubGroups2)
            .WithOne(subGroup2 => subGroup2.MainGroup)
            .HasForeignKey(subGroup2 => subGroup2.MainGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
