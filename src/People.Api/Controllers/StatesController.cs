using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People.Api.ViewModels;
using People.Domain.Services;

namespace People.Api.Controllers
{
    [Route("api")]
    [Authorize()]
    public class StatesController : Controller
    {
        IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, Route("v1/[controller]")]
        public IActionResult Get()
        {
            try
            {
                return Ok(new ResultViewModel { Success = true, Docs = _stateService.GetAll() });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }
    }
}