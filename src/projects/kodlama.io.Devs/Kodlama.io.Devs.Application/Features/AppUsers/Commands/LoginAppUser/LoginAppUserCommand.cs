using Kodlama.io.Devs.Application.Features.AppUsers.Models;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.LoginAppUser
{
    public class LoginAppUserCommand : IRequest<LoggedinAppUserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
