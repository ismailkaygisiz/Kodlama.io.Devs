using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }
    }
}
