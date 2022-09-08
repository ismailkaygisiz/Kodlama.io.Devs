using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology mappedTechnology = _mapper.Map<Technology>(request);
            Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
            
            IPaginate<Technology> technology = await _technologyRepository.GetListAsync(
                c => c.Id == createdTechnology.Id,
                include: p => p.Include(c => c.ProgrammingLanguage)
            );

            CreatedTechnologyDto createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(technology.Items.FirstOrDefault());

            return createdTechnologyDto;
        }
    }
}
