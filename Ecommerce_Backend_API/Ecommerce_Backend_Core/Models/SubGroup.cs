

using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class SubGroup
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();

        [ForeignKey(nameof(MainGroup))]
        public int MainGroupId { get; set; }
        public MainGroup MainGroup { get; set; }

        public ICollection<SubGroup2> SubGroups2 { get; set; } = new HashSet<SubGroup2>();

    }
}
