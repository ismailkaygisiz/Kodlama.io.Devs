using AutoMapper;
using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommandHandler : IRequestHandler<UpdateGithubAddressCommand, UpdatedGithubAddressAppUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;

        public UpdateGithubAddressCommandHandler(IMapper mapper, IAppUserRepository appUserRepository)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }

        public async Task<UpdatedGithubAddressAppUserDto> Handle(UpdateGithubAddressCommand request, CancellationToken cancellationToken)
        {
            AppUser mappedAppUser = _mapper.Map<AppUser>(request);
            AppUser appUser = await _appUserRepository.GetAsync(e => e.Id == mappedAppUser.Id);
            appUser.GithubAddress = mappedAppUser.GithubAddress;

            AppUser updatedAppUser = await _appUserRepository.UpdateAsync(appUser);
            UpdatedGithubAddressAppUserDto updatedGithubAddressAppUserDto = _mapper.Map<UpdatedGithubAddressAppUserDto>(updatedAppUser);

            return updatedGithubAddressAppUserDto;
        }
    }
}
