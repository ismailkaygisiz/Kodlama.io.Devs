using Kodlama.io.Devs.Application.Features.AppUsers.Commands.AddGithubAddress;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.DeleteGithubAddress;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.UpdateGithubAddress;
using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGithubAddress([FromBody] AddGithubAddressCommand request)
        {
            AddedGithubAddressAppUserDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGithubAddress([FromQuery] DeleteGithubAddressCommand request)
        {
            DeletedGithubAddressAppUserDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGithubAddress([FromBody] UpdateGithubAddressCommand request)
        {
            UpdatedGithubAddressAppUserDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
