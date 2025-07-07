
namespace Ecommerce_Backend_Core.Models
{
    public class Classification
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
