
namespace Ecommerce_Backend_Core.DTO_s
{
    public class GetItemsResponseDataDto
    {
       public IEnumerable<ItemDto> Items { get; set; } = [];
       public GetItemsResponseDataDto(IEnumerable<ItemDto> items) {
         Items = items;
       }
    }
}
