using Ecommerce_Backend_API.Helpers;
using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }

        [HttpPost("AddItemsToCart")]
        public async Task<IActionResult> AddBulkQuantityToCartAsync(
            [FromBody] CartItemDto cartItemDto
        )
        {
            // TODO: Validation for cartItemDto
            var token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (!userId.HasValue)
                {
                    return Unauthorized(new { message = "Invalid token" });
                }
                var addBulkQuantityToCartResult = await _cartRepository.AddBulkQuantityToCartAsync(
                    cartItemDto,
                    userId.Value
                );
                if (addBulkQuantityToCartResult is FailResponse failResponse)
                {
                    return Problem(
                        statusCode: (int)failResponse.StatusCode,
                        title: failResponse.Message,
                        detail: string.Join(", ", failResponse.Errors)
                    );
                }
                else
                {
                    return CreatedAtAction(null, addBulkQuantityToCartResult as SuccessResponse);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Something wrong happened");
            }
        }
    }
}
