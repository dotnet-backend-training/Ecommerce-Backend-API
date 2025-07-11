
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class ItemUnit
    {
        public int Factor { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
