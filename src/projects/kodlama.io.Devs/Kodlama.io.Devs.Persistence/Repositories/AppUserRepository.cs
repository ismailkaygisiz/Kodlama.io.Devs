using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class AppUserRepository : EfRepositoryBase<AppUser, int, BaseDbContext>, IAppUserRepository
    {
        public AppUserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
