using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IUserRepository : IRepository<User, int>, IAsyncRepository<User, int>
    {

    }
}
