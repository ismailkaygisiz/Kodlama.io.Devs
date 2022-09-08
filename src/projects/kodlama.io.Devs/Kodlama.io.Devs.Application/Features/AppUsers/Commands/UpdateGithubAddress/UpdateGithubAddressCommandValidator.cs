using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommandValidator : AbstractValidator<UpdateGithubAddressCommand>
    {
        public UpdateGithubAddressCommandValidator()
        {
            RuleFor(c => c.GithubAddress).NotEmpty()
        }
    }
}
