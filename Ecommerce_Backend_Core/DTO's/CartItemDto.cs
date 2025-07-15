
namespace Ecommerce_Backend_Core.DTO_s
{
    public class CartItemDto
    {
        public int ItemCode { get; set; }
        public double Price { get; set; }
        public int ItemUnitCode { get; set; } 
        public int StoreCode { get; set; }
        public double Quantity { get; set; }
    }
}
