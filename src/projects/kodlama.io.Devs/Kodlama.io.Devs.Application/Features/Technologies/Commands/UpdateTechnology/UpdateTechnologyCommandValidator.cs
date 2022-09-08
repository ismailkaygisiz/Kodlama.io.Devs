using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
