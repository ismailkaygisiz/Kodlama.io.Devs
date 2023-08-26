using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedinDto>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginCommandHandler(IAppUserRepository appUserRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _appUserRepository = appUserRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoggedinDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserMustBeExistsAndPasswordMustBeTrueWhenLoggedin(request.UserForLoginDto.Email, request.UserForLoginDto.Password);
            
            AppUser appUser = await _appUserRepository.GetAsync(e => e.Email == request.UserForLoginDto.Email);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(appUser);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(appUser, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            LoggedinDto loggedinDto = new()
            {
                RefreshToken = addedRefreshToken,
                AccessToken = createdAccessToken,
            };

            return loggedinDto;
        }
    }
}
