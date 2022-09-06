using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models
{
    public class GetListProgrammingLanguageModel : BasePageableModel
    {
        public IList<GetListProgrammingLanguageDto> Items { get; set; }
    }
}
