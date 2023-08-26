using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos
{
    public class GetListProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Technology> Technologies { get; set; }
    }
}
