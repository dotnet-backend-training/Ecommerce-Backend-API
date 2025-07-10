

namespace Ecommerce_Backend_Core.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<ItemUnit> ItemUnits { get; set; } = new HashSet<ItemUnit>();
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; } = new HashSet<InvoiceDetails>();
        public ICollection<ShoppingCartItems> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItems>();
    }
}
