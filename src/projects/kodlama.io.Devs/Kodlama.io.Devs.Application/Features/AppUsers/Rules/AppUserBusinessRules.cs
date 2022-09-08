using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Rules
{
    public class AppUserBusinessRules
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserBusinessRules(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task VerifyEmailOrPassword(AppUser appUser, string password)
        {
            if (appUser == null || !HashingHelper.VerifyPasswordHash(password, appUser?.PasswordHash, appUser?.PasswordSalt))
                throw new BusinessException("Email veya Parola Hatalı");
        }
        public async Task ControlUserEmail(string email)
        {
            var appUser = await _appUserRepository.GetAsync(e => e.Email == email);
            if (appUser != null)
                throw new BusinessException("Kullanıcı Mevcut");
        }
    }
}
