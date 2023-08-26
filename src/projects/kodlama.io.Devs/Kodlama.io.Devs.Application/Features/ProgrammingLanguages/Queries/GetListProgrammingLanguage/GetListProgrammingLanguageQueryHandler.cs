using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, GetListProgrammingLanguageModel>
    {
        private readonly IMapper _mapper;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetListProgrammingLanguageQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<GetListProgrammingLanguageModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(include: p => p.Include(t => t.Technologies), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            programmingLanguages.Items.RunAction(p => p.Technologies.RunAction(t => t.ProgrammingLanguage = null));
            
            GetListProgrammingLanguageModel mappedProgrammingLanguageModel = _mapper.Map<GetListProgrammingLanguageModel>(programmingLanguages);

            return mappedProgrammingLanguageModel;
        }
    }

    public static class IListExtensions
    {
        public static IList<T> RunAction<T>(this IList<T> list, Action<T> action)
        {
            list.ToList().ForEach(action);
            return list;
        }
        public static ICollection<T> RunAction<T>(this ICollection<T> collection, Action<T> action)
        {
            collection.ToList().ForEach(action);
            return collection;
        }
    }
}
