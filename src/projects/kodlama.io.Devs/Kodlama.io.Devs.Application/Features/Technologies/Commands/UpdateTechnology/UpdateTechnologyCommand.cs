using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}
