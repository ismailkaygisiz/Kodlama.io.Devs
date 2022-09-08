using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.Technologies.Models
{
    public class GetListTechnologyModel : BasePageableModel
    {
        public IList<GetListTechnologyDto> Items { get; set; }
    }
}
