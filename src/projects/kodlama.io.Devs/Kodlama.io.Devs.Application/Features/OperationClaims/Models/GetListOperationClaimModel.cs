using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Models
{
    public class GetListOperationClaimModel : BasePageableModel
    {
        public IList<GetListOperationClaimDto> Items { get; set; }
    }
}
