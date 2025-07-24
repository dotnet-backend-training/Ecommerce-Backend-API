using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository) {
            this._itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            var getAllItemsResult = await _itemRepository.GetItemsAsync();
            if (getAllItemsResult is FailResponse failResponse )
            {
                return Problem(
                    statusCode: (int)failResponse.StatusCode,
                    title: failResponse.Message,
                    detail: string.Join(", ",
                    failResponse.Errors
                    )
                );
            }
            if(getAllItemsResult is SuccessResponse<GetItemsResponseDataDto> successResponse       
            )
            {
                if(!successResponse.Data.Items.Any())
                {
                    // TODO: Should be changed to ok 
                    // the resouce exist but empty
                    return NotFound(
                        successResponse
                    );
                }
                return Ok(successResponse);
            }
            return StatusCode(500, "Unexpected response type.");
        }
    }
}
