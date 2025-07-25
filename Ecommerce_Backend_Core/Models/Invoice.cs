
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double NetPrice { get; set; }
        // TODO: create a sperate table for TransactionType
        public int TransactionType { get; set; }
        // TODO: create a sperate table for PaymentType
        public int PaymentType { get; set; }
        // TODO: move all statuses into a seperate table.
        public bool IsPosted { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }= new HashSet<InvoiceDetails>();

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public User Customer { get; set; } = null!;
    }
}
