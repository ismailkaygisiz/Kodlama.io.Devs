using AutoMapper;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.DeleteGithubAddress;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.UpdateGithubAddress;
using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, AddedGithubAddressAppUserDto>().ReverseMap();

            CreateMap<AppUser, DeletedGithubAddressAppUserDto>().ReverseMap();
            CreateMap<AppUser, DeleteGithubAddressCommand>().ReverseMap();
            
            CreateMap<AppUser, UpdatedGithubAddressAppUserDto>().ReverseMap();
            CreateMap<AppUser, UpdateGithubAddressCommand>().ReverseMap();
        }
    }
}
