
using Ecommerce_Backend_Core.Shared;

namespace Ecommerce_Backend_Core.Interfaces
{
    public interface IItemRepository
    {
        Task<ApiResponse> GetItemsAsync();
    }
}
