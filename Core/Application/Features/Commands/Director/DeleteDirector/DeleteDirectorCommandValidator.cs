using FluentValidation;

namespace Application.Features.Commands.Director.DeleteDirector;

public class DeleteDirectorCommandValidator: AbstractValidator<DeleteDirectorCommandRequest>
{
    public DeleteDirectorCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("idyi kontrol et");
    }
}