using AutoMapper;
using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.AddGithubAddress
{
    public class AddGithubAddressCommandHandler : IRequestHandler<AddGithubAddressCommand, AddedGithubAddressAppUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;

        public AddGithubAddressCommandHandler(IMapper mapper, IAppUserRepository appUserRepository)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }

        public async Task<AddedGithubAddressAppUserDto> Handle(AddGithubAddressCommand request, CancellationToken cancellationToken)
        {
            AppUser appUserToUpdate = await _appUserRepository.GetAsync(c=>c.Id == request.Id);
            appUserToUpdate.GithubAddress = request.GithubAddress;

            AppUser appUser = await _appUserRepository.UpdateAsync(appUserToUpdate);

            AddedGithubAddressAppUserDto addedGithubAddressAppUserDto = _mapper.Map<AddedGithubAddressAppUserDto>(appUser);
            return addedGithubAddressAppUserDto;
        }
    }
}
