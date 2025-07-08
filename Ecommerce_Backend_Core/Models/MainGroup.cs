

namespace Ecommerce_Backend_Core.Models
{
    public class MainGroup
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
        public ICollection<SubGroup> SubGroups  { get; set; } = new HashSet<SubGroup>();
        public ICollection<SubGroup2> SubGroups2 { get; set; } = new HashSet<SubGroup2>();


    }
}
