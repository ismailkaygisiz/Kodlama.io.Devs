using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IOperationClaimRepository : IRepository<OperationClaim, int>, IAsyncRepository<OperationClaim, int>
    {

    }
}
