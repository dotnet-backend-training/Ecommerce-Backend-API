
using Ecommerce_Backend_Core.DTO_s;

namespace Ecommerce_Backend_Core.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemDto>> GetItemsAsync();
    }
}
