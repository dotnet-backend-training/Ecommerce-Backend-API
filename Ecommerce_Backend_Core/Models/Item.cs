using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce_Backend_Core.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public ICollection<InventoryItemStore> InventoryItemStores { get; set; } = new HashSet<InventoryItemStore>();
        public ICollection<ItemUnit> ItemUnits { get; set; } = new HashSet<ItemUnit>();
        public ICollection <InvoiceDetails> InvoiceDetails { get; set; } = new HashSet <InvoiceDetails>();
        public ICollection<ShoppingCartItems> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItems>();

        [ForeignKey(nameof(MainGroup))]
        public int MainGroupId { get; set; }
        public MainGroup MainGroup { get; set; } = null!;

        [ForeignKey(nameof(SubGroup))]
        public int SubGroupId { get; set; }
        public SubGroup SubGroup { get; set; } = null!;

        [ForeignKey(nameof(SubGroup2))]
        public int SubGroup2Id { get; set; }
        public SubGroup2 SubGroup2 { get; set; } = null!;
    }
}
