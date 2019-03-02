using Microsoft.IdentityModel.Tokens;

namespace People.Api.Security
{
    public interface ITokenService
    {
        object CreateJwtToken();
    }
}
