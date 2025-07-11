using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    internal class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.HasKey(zone => zone.Id);

            /*
            * Zone -> Users
            * One Zone can have many Users.
            * Each User belongs to one Zone.
            */
            builder.HasMany(zone => zone.Users)
            .WithOne(user => user.Zone)
            .HasForeignKey(user => user.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Zone -> Stores
            * One Zone can have many Stores.
            * Each Store belongs to one Zone.
            */
            builder.HasMany(zone => zone.Stores)
            .WithOne(store => store.Zone)
            .HasForeignKey(store => store.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Zone -> Government
            * Each Zone belongs to one Government.
            * One Government can have many Zones.
            */
            builder.HasOne(zone => zone.Government)
            .WithMany(government => government.Zones)
            .HasForeignKey(zone => zone.GovernmentId)
            .OnDelete(DeleteBehavior.Restrict);


            /*
            * Zone -> City
            * Each Zone belongs to one City.
            * One Zone can have many Cities.
            */
            builder.HasOne(zone => zone.City)
            .WithMany(city=> city.Zones)
            .HasForeignKey(zone => zone.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
