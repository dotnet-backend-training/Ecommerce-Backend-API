using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class Store
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<InventoryItemStore> InventoryItemStore { get; set; } = new HashSet<InventoryItemStore>();

        [ForeignKey(nameof(Government))]
        public int GovernmentId { get; set; }
        public Government Government { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }

        [ForeignKey(nameof(Zone))]
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
    }
}
