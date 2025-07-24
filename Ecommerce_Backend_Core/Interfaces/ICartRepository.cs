
using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Shared;

namespace Ecommerce_Backend_Core.Interfaces
{
    public interface ICartRepository
    {
       Task<ApiResponse> AddBulkQuantityToCartAsync(CartItemDto cartItemDto, int userId) ;
       Task<ApiResponse> AddOneQuantityToCartAsync(CartItemDto cartItemDto, int userId);
       Task<ApiResponse> GetAllItemsFromCart(int customerId);
    }
}
