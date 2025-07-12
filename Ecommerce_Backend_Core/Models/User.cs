using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce_Backend_Core.Models
{
    public class User : IdentityUser<int>
    {
        public ICollection<CustomerStore> CustomerStores { get; set; } = new HashSet<CustomerStore>();
        public ICollection<InventoryItemStore> InventoryItems { get; set; } = new HashSet<InventoryItemStore>();
        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public ICollection<ShoppingCartItems> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItems>();

        [ForeignKey(nameof(Government))]
        public int GovernmentId {  get; set; }
        public Government Government { get; set; } = null!;

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        [ForeignKey(nameof(Zone))]
        public int ZoneId { get; set; }
        public Zone Zone { get; set; } = null!;

        [ForeignKey(nameof(Classification))]
        public int ClassificationId { get; set; }
        public Classification Classification { get; set; } = null!;
    }
}
