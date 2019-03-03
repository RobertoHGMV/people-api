using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People.Api.Security;
using System;

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
            try
            {
                return Ok(_tokenService.CreateJwtToken());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}