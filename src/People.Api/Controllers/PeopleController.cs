using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People.Api.ViewModels;
using People.Domain.Services;
using People.Domain.ViewModels;

namespace People.Api.Controllers
{
    [Route("api")]
    [Authorize()]
    public class PeopleController : Controller
    {
        IPersonService _service;

        public PeopleController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet, Route("v1/[controller]")]
        public IActionResult Get()
        {
            try
            {
                return Ok(new ResultViewModel { Success = true, Docs = _service.GetAll() });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }

        [HttpGet, Route("v1/[controller]/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var person = _service.GetByKey(id);
                if (person == null)
                    return NotFound(new ResultViewModel { Success = false, Docs = { } });

                return Ok(new ResultViewModel { Success = true, Docs = person });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }

        [HttpGet, Route("v1/[controller]/{uf:int}")]
        public IActionResult GetByUf(int uf)
        {
            try
            {
                return Ok(new ResultViewModel { Success = true, Docs = _service.GetByUf(uf) });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }

        [HttpPost, Route("v1/[controller]")]
        public IActionResult Post([FromBody] PersonAddModel personAddModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Dados inválidos");

                var person = _service.Add(personAddModel);
                if (person.HasNotifications)
                    return BadRequest(new ResultViewModel { Success = false, Docs = person.Notifications });

                return Created($"v1/people/{person.Id}", new ResultViewModel { Success = true, Docs = _service.CreatePersonListModel(person) });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }

        [HttpPut, Route("v1/[controller]/{id}")]
        public IActionResult Put(Guid id, [FromBody] PersonEditModel personEditModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Dados inválidos");

                var person = _service.Update(id, personEditModel);
                if (person.HasNotifications)
                    return BadRequest(new ResultViewModel { Success = false, Docs = person.Notifications });

                return Ok(new ResultViewModel { Success = true, Docs = _service.CreatePersonListModel(person) });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }

        [HttpDelete, Route("v1/[controller]/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel { Success = false, Docs = ex });
            }
        }
    }
}