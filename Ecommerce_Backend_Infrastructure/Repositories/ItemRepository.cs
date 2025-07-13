
using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            List<ItemDto> itemsDto = await _appDbContext.Items
                .Include(item => item.ItemUnits)
                .Select(item => 
                 new ItemDto()
                 {
                     Id = item.Id,
                     Name = item.Name,
                     Description = item.Description ?? "",
                     Price = item.Price,
                     ItemUnits = item.ItemUnits
                     .Select(itemUnit => itemUnit.Unit.Name).ToList()
                 }
                )
                .ToListAsync();
            return itemsDto;
        }
    }
}
