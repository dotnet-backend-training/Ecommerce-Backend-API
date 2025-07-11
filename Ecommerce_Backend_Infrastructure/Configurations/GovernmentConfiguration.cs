

using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    public class GovernmentConfiguration : IEntityTypeConfiguration<Government>
    {
        public void Configure(EntityTypeBuilder<Government> builder)
        {
            builder.HasKey(government => government.Id);

            builder.HasData(
                new Government { Id = 1, Name = "Egypt" },
                new Government { Id = 2, Name = "Palestine" },
                new Government { Id = 3, Name = "Jordan" },
                new Government { Id = 4, Name = "Lebanon" },
                new Government { Id = 5, Name = "Syria" }
            );

            /*
             - Government -> User
                * A Government can have Many Users
                * A User belong to One Government
            */
            builder.HasMany(government => government.Users) 
            .WithOne(user => user.Government)
            .HasForeignKey(user => user.GovernmentId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
             - Government -> Zone
                * A Government can have Many Zones
                * A Zone belong to One Government
             */
             builder.HasMany(government => government.Zones)
            .WithOne(zone => zone.Government)
            .HasForeignKey(zone => zone.GovernmentId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
              - Government -> City
                 * A Government can have Many Cities
                * A City belong to One Government
            */
           builder.HasMany(government => government.Cities)
          .WithOne(city => city.Government)
          .HasForeignKey(city => city.GovernmentId)
          .OnDelete(DeleteBehavior.Restrict);


            /*
            - Government -> Store
               * A Government can have Many Stores
              * A Store belong to One Government
          */
            builder.HasMany(government => government.Stores)
           .WithOne(store => store.Government)
           .HasForeignKey(store => store.GovernmentId)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
