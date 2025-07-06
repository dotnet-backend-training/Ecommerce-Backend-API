

namespace Ecommerce_Backend_Core.Models
{
    public class SubGroup
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();

    }
}
