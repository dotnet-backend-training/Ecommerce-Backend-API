
using Ecommerce_Backend_Core.DTO_s;
using Ecommerce_Backend_Core.Models;
using Mapster;

namespace Ecommerce_Backend_Core.MappingProfile
{
    public class MappingProfile
    {
        private static readonly TypeAdapterConfig _config =
            new TypeAdapterConfig();
        static MappingProfile() {
            _config.NewConfig<Item, ItemDto>()
            .Map(
             member: itemDto => itemDto.ItemUnits,
             source: item => item.ItemUnits.Select(
                itemUnit => itemUnit.Unit.Name
             ).ToList()
            )
            .Map(
             member: itemDto => itemDto.ItemStores,
             source: item => item.InventoryItemStores.Select(
                inventoryItemStore => inventoryItemStore.Store.Name
             ).ToList()
            );
        }
        public static TypeAdapterConfig Configuration => _config;
    }
}
