using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public DeleteTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology mappedTechnology = _mapper.Map<Technology>(request);
            
            IPaginate<Technology> technologyToDelete = await _technologyRepository.GetListAsync(
                e => e.Id == mappedTechnology.Id,
                include: p => p.Include(c => c.ProgrammingLanguage)
            );

            await _technologyRepository.DeleteAsync(technologyToDelete.Items.FirstOrDefault());

            DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(technologyToDelete.Items.FirstOrDefault());

            return deletedTechnologyDto;
        }
    }
}
