using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
        }
    }
}
