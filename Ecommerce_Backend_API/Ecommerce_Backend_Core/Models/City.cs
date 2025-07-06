using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend_Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();

        [ForeignKey(nameof(Government))]
        public int GovernmentId { get; set; }
        public required Government Government { get; set; }
        public ICollection<Zone> Zones { get; set; } = new HashSet<Zone>();

    }
}
