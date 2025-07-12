
namespace Ecommerce_Backend_Core.DTO_s
{
    public record LoginRequestDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
