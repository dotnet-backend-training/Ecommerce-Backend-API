﻿using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Core.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(city => city.Id);

            builder.Property(city => city.Name)
            .IsRequired();

            // City -> Government
            builder.HasOne(city => city.Government) // City has One Government
            .WithMany(government => government.Cities) // Government has Many Cities.
            .HasForeignKey(city => city.GovernmentId)
            .OnDelete(DeleteBehavior.Restrict);

            // City -> User 
            builder.HasMany(city => city.Users) // City has Many Users.
            .WithOne(user => user.City) // User belong to One City.
            .HasForeignKey(user => user.CityId)
            .OnDelete(DeleteBehavior.Restrict);

            // City -> Zone 
            builder.HasMany(city => city.Zones) // City has Many Zones.
            .WithOne(zone => zone.City) // Zone belong to One City.
            .HasForeignKey(zone => zone.CityId)
            .OnDelete(DeleteBehavior.Restrict);

            // City -> Store
            builder.HasMany(city => city.Stores) // City has Many Stores.
            .WithOne(store => store.City) // Store belong to One City.
            .HasForeignKey(store => store.CityId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
