using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommand : IRequest<UpdatedGithubAddressAppUserDto>
    {
        public int Id { get; set; }
        public string GithubAddress { get; set; }
    }
}
