using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ecommerce_Backend_API.Helpers
{
    public class ExtractClaims
    {
        public static int? ExtractUserId(string token)
        {
            try
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(
                    claim => claim.Type == ClaimTypes.NameIdentifier
                );
                if (userIdClaim is not null
                    && int.TryParse(userIdClaim.Value, out int userId)
                )
                {
                    return userId;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
