

using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class SubGroup2
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();

        [ForeignKey(nameof(MainGroup))]
        public int MainGroupId { get; set; }
        public MainGroup MainGroup { get; set; }

        [ForeignKey(nameof(SubGroup))]
        public int SubGroupId { get; set; }
        public SubGroup SubGroup { get; set; }


    }
}
