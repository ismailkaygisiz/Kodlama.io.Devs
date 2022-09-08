using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.DeleteGithubAddress
{
    public class DeleteGithubAddressCommand : IRequest<DeletedGithubAddressAppUserDto>
    {
        public int Id { get; set; }
    }
}
