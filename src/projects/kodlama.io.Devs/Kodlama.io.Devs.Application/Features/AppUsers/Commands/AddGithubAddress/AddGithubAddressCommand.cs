using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.AppUsers.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.AddGithubAddress
{
    public class AddGithubAddressCommand : IRequest<AddedGithubAddressAppUserDto>
    {
        public int Id { get; set; }
        public string GithubAddress { get; set; }
    }
}
