using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IAppUserRepository : IRepository<AppUser, int>, IAsyncRepository<AppUser, int>
    {

    }
}
