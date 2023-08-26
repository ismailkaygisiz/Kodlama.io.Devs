using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists");
        }

        public async Task UserMustBeExistsAndPasswordMustBeTrueWhenLoggedin(string email, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null || !HashingHelper.VerifyPasswordHash(password, user?.PasswordHash, user?.PasswordSalt))
            {
                throw new BusinessException("Email veya Parola Hatalı");
            }
        }
    }
}
