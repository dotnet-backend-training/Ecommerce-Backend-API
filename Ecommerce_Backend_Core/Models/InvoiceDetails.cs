
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class InvoiceDetails
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public double Factor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
