
using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Core.Shared;
using Ecommerce_Backend_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Ecommerce_Backend_Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _appDbContext;

        public CartRepository(
            AppDbContext appDbContext
        ) {
            this._appDbContext = appDbContext;
        }

        public async Task<ApiResponse> AddBulkQuantityToCartAsync(
            CartItemDto cartItemDto,
            int? userId
            )
        {
            var item = await _appDbContext.Items.FindAsync(
                cartItemDto.ItemCode
            );
            var store = await _appDbContext.Stores.FindAsync(
             cartItemDto.StoreCode
            );
            if(item is null || store is null)
            {
                var errorMessage = (item, store) switch
                {
                    (null, null) => "Item and Store not found!",
                    (null, _) => "Item not found!",
                    (_, null) => "Store not found!",
                    _ => "Something wrong happened"
                };
                return FailResponse.CreateWithError(
                    message: "Failed to add the item to the cart.",
                    error: errorMessage,
                    statusCode: HttpStatusCode.NotFound
                );
            }
            var existingShoppingCartItem = await _appDbContext.ShoppingCartItems.FirstOrDefaultAsync(
                    shoppingCartItem => 
                    shoppingCartItem.CustomerId == userId 
                    && shoppingCartItem.ItemId == cartItemDto.ItemCode
                    && shoppingCartItem.StoreId == cartItemDto.StoreCode
            );
            if (existingShoppingCartItem is not null)
            {
                existingShoppingCartItem.Quantity += cartItemDto.Quantity;
                existingShoppingCartItem.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var shoppingCartItem = new ShoppingCartItems()
                {
                    ItemId = cartItemDto.ItemCode,
                    StoreId = cartItemDto.StoreCode,
                    CustomerId = userId,
                    UnitId = cartItemDto.ItemUnitCode,
                    CreatedAt = DateTime.UtcNow,
                    Quantity = cartItemDto.Quantity,
                };
               await _appDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            await _appDbContext.SaveChangesAsync();
            return SuccessResponse.Create(
                message: "Item added to cart successfully.",
                statusCode: HttpStatusCode.Created
            );
        }

        public async Task<ApiResponse> AddOneQuantityToCartAsync(
            CartItemDto cartItemDto,
            int? userId)
        {
            var item = await _appDbContext.Items.FindAsync(cartItemDto.ItemCode);
            var store = await _appDbContext.Stores.FindAsync(
             cartItemDto.StoreCode
            );
            if (item is null || store is null)
            {
                var errorMessage = (item, store) switch
                {
                    (null, null) => "Item and Store not found!",
                    (null, _) => "Item not found!",
                    (_, null) => "Store not found!",
                    _ => "Something wrong happened"
                };
                return FailResponse.CreateWithError(
                    message: "Failed to add the item to the cart.",
                    error: errorMessage,
                    statusCode: HttpStatusCode.NotFound
                );
            }
            var existingShoppingCartItem = await _appDbContext.ShoppingCartItems.FirstOrDefaultAsync(
                    shoppingCartItem =>
                    shoppingCartItem.CustomerId == userId
                    && shoppingCartItem.ItemId == cartItemDto.ItemCode
                    && shoppingCartItem.StoreId == cartItemDto.StoreCode
            );
            if (existingShoppingCartItem is not null)
            {
                existingShoppingCartItem.Quantity += 1;
                existingShoppingCartItem.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var shoppingCartItem = new ShoppingCartItems()
                {
                    ItemId = cartItemDto.ItemCode,
                    StoreId = cartItemDto.StoreCode,
                    CustomerId = userId,
                    UnitId = cartItemDto.ItemUnitCode,
                    CreatedAt = DateTime.UtcNow,
                    Quantity = 1,
                };
              await _appDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            await _appDbContext.SaveChangesAsync();
            return SuccessResponse.Create(
                message: "Item added to cart successfully.",
                statusCode: HttpStatusCode.Created
            );
        }
    }
}
