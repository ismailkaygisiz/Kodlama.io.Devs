using AutoMapper;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.AppUsers.Models;
using Kodlama.io.Devs.Application.Features.AppUsers.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.RegisterAppUser
{
    public class RegisterAppUserCommandHandler : IRequestHandler<RegisterAppUserCommand, RegisteredAppUserModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        public RegisterAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository, ITokenHelper tokenHelper, AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _tokenHelper = tokenHelper;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<RegisteredAppUserModel> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
        {
            await _appUserBusinessRules.ControlUserEmail(request.Email);

            HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

            AppUser mappedAppUser = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                GithubAddress = "",
                AuthenticatorType = AuthenticatorType.None,
                Status = true,
            };

            AppUser appUser = await _appUserRepository.AddAsync(mappedAppUser);

            AccessToken accessToken = _tokenHelper.CreateToken(appUser, new List<OperationClaim>());

            RegisteredAppUserModel registeredAppUserModel = new RegisteredAppUserModel()
            {
                AccessToken = accessToken
            };

            return registeredAppUserModel;
        }
    }
}
