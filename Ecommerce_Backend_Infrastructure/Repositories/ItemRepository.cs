
using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.MappingProfile;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Core.Shared;
using Ecommerce_Backend_Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Ecommerce_Backend_Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository(
            AppDbContext appDbContext    
        )
        {
            this._appDbContext = appDbContext;
        }
        public async Task<ApiResponse> GetItemsAsync()
        {
            var mappingProfileConfiguration = MappingProfile.Configuration;
            List<ItemDto> itemsDto = await _appDbContext.Items
                .ProjectToType<ItemDto>(mappingProfileConfiguration)
                .ToListAsync();
            if (itemsDto.Count < 1 )
            {
                return SuccessResponse.Create
                (
                    message: "No items found.",
                    statusCode: HttpStatusCode.NotFound
                );
            }
            return SuccessResponse<GetItemsResponseDataDto>.Create
            (
                message: "Items retrieved successfully.",
                data: new GetItemsResponseDataDto
                (
                    items: itemsDto
                )
            );
        }
    }
}
