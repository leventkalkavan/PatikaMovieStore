using FluentValidation;

namespace Application.Features.Commands.Actor.DeleteActor;

public class DeleteActorCommandValidator: AbstractValidator<DeleteActorCommandRequest>
{
    public DeleteActorCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("idyi kontrol et");
    }
}