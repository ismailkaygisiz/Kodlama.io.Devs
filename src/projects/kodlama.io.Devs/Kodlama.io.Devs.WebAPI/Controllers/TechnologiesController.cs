using Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand request)
        {
            CreatedTechnologyDto result = await Mediator.Send(request);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTechnologyCommand request)
        {
            DeletedTechnologyDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand request)
        {
            UpdatedTechnologyDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListTechnologyQuery request)
        {
            GetListTechnologyModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery request)
        {
            GetByIdTechnologyDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
