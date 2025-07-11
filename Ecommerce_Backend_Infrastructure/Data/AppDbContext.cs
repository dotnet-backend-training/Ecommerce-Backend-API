
using Ecommerce_Backend_Core.Configurations;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ecommerce_Backend_Infrastructure.Data
{
    public class AppDbContext: IdentityDbContext<User, IdentityRole<int>,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    
        public DbSet<City> Cities { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<CustomerStore> CustomerStores { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<InventoryItemStore> InventoryItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoicesDetails { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemUnit> ItemUnits { get; set; }
        public DbSet<MainGroup> MainGroups { get; set; }    
        public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
        public DbSet<Store> Stores { get; set; }    
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<SubGroup2> SubGroup2s { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users {  get; set; }
        public DbSet<Zone> Zone { get; set; }

    } 
}
