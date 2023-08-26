using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IRepository<UserOperationClaim, int>, IAsyncRepository<UserOperationClaim, int>
    {

    }
}
