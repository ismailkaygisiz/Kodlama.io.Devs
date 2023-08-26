using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<GetListOperationClaimModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
