using FluentValidation;

namespace Application.Features.Commands.Actor.CreateActor;

public class CreateActorCommandValidator: AbstractValidator<CreateActorCommandRequest>
{
    public CreateActorCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("The name should not be empty.")
            .MaximumLength(20)
            .MinimumLength(2)
            .WithMessage("The 'name' value should be in the number of characters from 3 to 20.");
        RuleFor(x => x.Surname).NotNull().WithMessage("The surname should not be empty")
            .MaximumLength(20)
            .MinimumLength(2)
            .WithMessage("The 'name' value should be in the number of characters from 3 to 20.");
    }
}