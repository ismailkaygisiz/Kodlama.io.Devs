using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken, int>, IAsyncRepository<RefreshToken, int>
    {

    }
}
