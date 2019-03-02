using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People.Api.Security;

namespace People.Api.Controllers
{
    [Route("api")]
    public class AuthorizationController : Controller
    {
        ITokenService _tokenService;

        public AuthorizationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/[controller]")]
        public IActionResult Authenticate()
        {
            var jwtToken = _tokenService.CreateJwtToken();
            return Ok(jwtToken);
        }
    }
}