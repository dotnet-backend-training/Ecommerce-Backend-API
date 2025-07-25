
namespace Ecommerce_Backend_Core.DTO_s
{
    public class InvoiceReceiptDto
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new List<InvoiceItemDto>();
    }
}
