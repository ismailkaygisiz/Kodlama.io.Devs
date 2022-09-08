using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public UpdateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology mappedTechnology = _mapper.Map<Technology>(request);
            Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
            
            IPaginate<Technology> technology = await _technologyRepository.GetListAsync(
              c => c.Id == updatedTechnology.Id,
              include: p => p.Include(c => c.ProgrammingLanguage)
            );


            UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(technology.Items.FirstOrDefault());

            return updatedTechnologyDto;
        }
    }
}
