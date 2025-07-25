
namespace Ecommerce_Backend_Core.DTO_s
{
    public class InvoiceItemDto
    {
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public double PricePerUnit { get; set; }
        public double TotalPrice { get; set; }
    }
}
