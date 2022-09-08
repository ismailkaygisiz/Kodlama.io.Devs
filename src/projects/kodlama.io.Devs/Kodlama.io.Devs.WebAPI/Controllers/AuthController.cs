using Kodlama.io.Devs.Application.Features.AppUsers.Commands.LoginAppUser;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.RegisterAppUser;
using Kodlama.io.Devs.Application.Features.AppUsers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterAppUserCommand request)
        {
            RegisteredAppUserModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserCommand request)
        {
            LoggedinAppUserModel result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
