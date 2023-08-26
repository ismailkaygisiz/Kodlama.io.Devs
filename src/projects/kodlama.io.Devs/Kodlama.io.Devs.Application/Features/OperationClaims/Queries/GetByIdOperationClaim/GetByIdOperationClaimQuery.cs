using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<GetByIdOperationClaimDto>
    {
        public int Id { get; set; }
    }
}
