using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.AppUsers.Models;
using Kodlama.io.Devs.Application.Features.AppUsers.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.LoginAppUser
{
    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, LoggedinAppUserModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public LoginAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository, ITokenHelper tokenHelper, AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _tokenHelper = tokenHelper;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<LoggedinAppUserModel> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _appUserRepository.GetAsync(e => e.Email == request.Email);

            await _appUserBusinessRules.VerifyEmailOrPassword(appUser, request.Password);

            AccessToken accessToken = _tokenHelper.CreateToken(appUser, new List<OperationClaim>());
            LoggedinAppUserModel loggedinAppUserModel = new LoggedinAppUserModel()
            {
                AccessToken = accessToken
            };

            return loggedinAppUserModel;
        }
    }
}
