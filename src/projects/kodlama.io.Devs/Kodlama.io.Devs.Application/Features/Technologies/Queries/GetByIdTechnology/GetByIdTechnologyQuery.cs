using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDto>
    {
        public int Id { get; set; }
    }
}
