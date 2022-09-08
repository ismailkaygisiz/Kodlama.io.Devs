using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.AppUsers.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.RegisterAppUser
{
    public class RegisterAppUserCommand : IRequest<RegisteredAppUserModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
