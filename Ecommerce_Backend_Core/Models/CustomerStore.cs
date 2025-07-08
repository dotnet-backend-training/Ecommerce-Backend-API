
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Backend_Core.Models
{
    public class CustomerStore
    {
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public User Customer {  get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
