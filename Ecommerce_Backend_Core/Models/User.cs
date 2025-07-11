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
        public required Government Government { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public required City City { get; set; }

        [ForeignKey(nameof(Zone))]
        public int ZoneId { get; set; }
        public required Zone Zone { get; set; }

        [ForeignKey(nameof(Classification))]
        public int ClassificationId { get; set; }
        public Classification Classification { get; set; }
    }
}
