

namespace Ecommerce_Backend_Core.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<ItemUnit> ItemUnits { get; set; } = new HashSet<ItemUnit>();
    }
}
