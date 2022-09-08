using AutoMapper;
using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.DeleteGithubAddress
{
    public class DeleteGithubAddressCommandHandler : IRequestHandler<DeleteGithubAddressCommand, DeletedGithubAddressAppUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;

        public DeleteGithubAddressCommandHandler(IMapper mapper, IAppUserRepository appUserRepository)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }

        public async Task<DeletedGithubAddressAppUserDto> Handle(DeleteGithubAddressCommand request, CancellationToken cancellationToken)
        {
            AppUser mappedAppUser = _mapper.Map<AppUser>(request);
            AppUser appUser = await _appUserRepository.GetAsync(e=>e.Id == mappedAppUser.Id);
            appUser.GithubAddress = "";

            appUser = await _appUserRepository.UpdateAsync(appUser);

            DeletedGithubAddressAppUserDto deletedGithubAddressAppUserDto = _mapper.Map<DeletedGithubAddressAppUserDto>(appUser);
            return deletedGithubAddressAppUserDto;
        }
    }
}
