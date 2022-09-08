using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.AddGithubAddress
{
    public class AddGithubAddressCommandValidator : AbstractValidator<AddGithubAddressCommand>
    {
        public AddGithubAddressCommandValidator()
        {
            RuleFor(c => c.GithubAddress).NotEmpty();
        }
    }
}
