
namespace Ecommerce_Backend_Core.DTO_s
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public List<string> ItemUnits { get; set; } = [];
        public List<string> ItemStores { get; set; } = [];
    }
}
