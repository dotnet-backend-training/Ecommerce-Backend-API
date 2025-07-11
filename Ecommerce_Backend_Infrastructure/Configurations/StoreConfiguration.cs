﻿
using Ecommerce_Backend_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_Backend_Infrastructure.Configurations
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(store => store.Id);

            /*
            * Store -> InventoryItemStores (Join table btw item and store)
            * One Store has Many InventoryItemStores.
            * One InventoryItemStore related to One Store. 
            */
            builder.HasMany(store => store.InventoryItemStores)
            .WithOne(inventoryItemStore => inventoryItemStore.Store)
            .HasForeignKey(inventoryItemStore => inventoryItemStore.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * Store -> CustomerStores (Join table btw customer and store)
            * One Store has Many CustomerStores.
            * One CustomerStores related to One Store. 
            */
            builder.HasMany(store => store.CustomerStores)
            .WithOne(customerStore => customerStore.Store)
            .HasForeignKey(customerStore => customerStore.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

            /*
            * Store -> ShoppingCartItems (Join table btw item and store and customer)
            * One Store can have Many ShoppingCartItems.
            * One ShoppingCartItems is associated with one Store.
            */
            builder.HasMany(store => store.ShoppingCartItems)
            .WithOne(shoppingCartItems => shoppingCartItems.Store)
            .HasForeignKey(shoppingCartItems => shoppingCartItems.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Store -> Government 
            * One Store belong to One Government
            * One Government can have Many Stores
            */
            builder.HasOne(store => store.Government)
            .WithMany(government => government.Stores)
            .HasForeignKey(store => store.GovernmentId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Store -> City 
            * One Store belong to One City
            * One City can have Many Stores
            */
            builder.HasOne(store => store.City)
            .WithMany(city => city.Stores)
            .HasForeignKey(store => store.CityId)
            .OnDelete(DeleteBehavior.Restrict);

            /*
            * Store -> Zone 
            * One Store belong to One Zone
            * One Zone can have Many Stores
            */
            builder.HasOne(store => store.Zone)
            .WithMany(zone => zone.Stores)
            .HasForeignKey(store => store.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
