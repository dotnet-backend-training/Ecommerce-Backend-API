
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class ShoppingCartItems
    {
        public double Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public User Customer { get; set; } = null!;

        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; } = null!;

        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!;
    }
}
