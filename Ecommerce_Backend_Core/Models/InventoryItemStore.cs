
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class InventoryItemStore
    {
        public double Balance { get; set; }
        public int Factor { get; set; }
        public double ReservedQuantity { get; set; } 
        public DateTime LastUpdated { get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId {  get; set; }
        public Item Item { get; set; }

    }
}
