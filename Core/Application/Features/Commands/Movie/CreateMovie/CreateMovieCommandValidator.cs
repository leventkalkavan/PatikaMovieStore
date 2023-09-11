using FluentValidation;

namespace Application.Features.Commands.Movie.CreateMovie;

public class CreateMovieCommandValidator: AbstractValidator<CreateMovieCommandRequest>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("The name should not be empty.");
        RuleFor(x => x.Type).NotNull().WithMessage("The type should not be empty.");
        RuleFor(x => x.Year).NotNull().WithMessage("The year should not be empty.");
    }
}