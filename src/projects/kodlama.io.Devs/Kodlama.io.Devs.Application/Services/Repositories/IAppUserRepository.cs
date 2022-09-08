using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IAppUserRepository : IRepository<AppUser>, IAsyncRepository<AppUser>
    {

    }
}
