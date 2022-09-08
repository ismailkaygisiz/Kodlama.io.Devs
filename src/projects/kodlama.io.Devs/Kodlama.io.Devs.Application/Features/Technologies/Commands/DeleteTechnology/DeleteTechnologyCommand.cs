using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
    }
}
