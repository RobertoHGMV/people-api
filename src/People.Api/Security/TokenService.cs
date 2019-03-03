using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace People.Api.Security
{
    public class TokenService : ITokenService
    {
        IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Criação de Token

        public object CreateJwtToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityTokenDescriptor = GetSecurityTokenDescriptor();
            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(securityToken);
            var expiration = securityTokenDescriptor.Expires.Value;

            return new { accessToken = jwtSecurityToken, expiresIn = expiration };
        }

        private SymmetricSecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
        }

        private SigningCredentials GetSigningCredentials()
        {
            var securityKey = GetSecurityKey();
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        private ClaimsIdentity GetClaimsIdentity()
        {
            return new ClaimsIdentity
            (
                new GenericIdentity("email"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "user")
                }
            );
        }

        private SecurityTokenDescriptor GetSecurityTokenDescriptor()
        {
            var claimsIdentity = GetClaimsIdentity();
            var signingCredentials = GetSigningCredentials();
            var tokenSettings = new TokenSettings();

            return new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = tokenSettings.Issuer,
                Audience = tokenSettings.Audience,
                IssuedAt = tokenSettings.IssuedAt,
                NotBefore = tokenSettings.NotBefore,
                Expires = tokenSettings.Expiration,
                SigningCredentials = signingCredentials
            };
        }

        #endregion
    }
}
