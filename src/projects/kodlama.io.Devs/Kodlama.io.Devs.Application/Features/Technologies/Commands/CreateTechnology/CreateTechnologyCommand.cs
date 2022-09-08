using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}
