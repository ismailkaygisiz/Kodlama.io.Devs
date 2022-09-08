using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery : IRequest<GetListTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, GetListTechnologyModel>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;

        public GetListTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
        }

        public async Task<GetListTechnologyModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(
                include: p => p.Include(c => c.ProgrammingLanguage),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
            );

            GetListTechnologyModel mappedTechnologyModel = _mapper.Map<GetListTechnologyModel>(technologies);
            return mappedTechnologyModel;
        }
    }
}
