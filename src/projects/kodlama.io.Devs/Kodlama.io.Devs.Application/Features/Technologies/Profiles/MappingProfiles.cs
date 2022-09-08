using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, CreatedTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, DeletedTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();

            CreateMap<Technology, GetByIdTechnologyQuery>().ReverseMap();
            CreateMap<Technology, GetByIdTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();

            CreateMap<Technology, GetListTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>, GetListTechnologyModel>().ReverseMap();
        }
    }
}
