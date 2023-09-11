using FluentValidation;

namespace Application.Features.Commands.Movie.DeleteMovie;

public class DeleteMovieCommandValidator: AbstractValidator<DeleteMovieCommandsRequest>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("idyi kontrol et");
    }
}