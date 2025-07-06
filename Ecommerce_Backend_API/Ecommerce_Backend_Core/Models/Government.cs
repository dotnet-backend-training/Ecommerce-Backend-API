

namespace Ecommerce_Backend_Core.Models
{
    public class Government
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();

        public ICollection<Zone> Zones { get; set; } = new HashSet<Zone>();

        public ICollection<City> Cities { get; set; } = new HashSet<City>();


    }
}
