using Core.Security.Dtos;
using Core.Security.Enums;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.AppUsers.Rules;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoggedinDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }
    }
}
