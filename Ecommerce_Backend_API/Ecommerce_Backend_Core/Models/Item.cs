using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce_Backend_Core.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(MainGroup))]
        public int MainGroupId { get; set; }
        public required MainGroup MainGroup { get; set; }

        [ForeignKey(nameof(SubGroup))]
        public int SubGroupId { get; set; }
        public required SubGroup SubGroup { get; set; }

        [ForeignKey(nameof(SubGroup2))]
        public int SubGroup2Id { get; set; }
        public required SubGroup2 SubGroup2 { get; set; }
    }
}
