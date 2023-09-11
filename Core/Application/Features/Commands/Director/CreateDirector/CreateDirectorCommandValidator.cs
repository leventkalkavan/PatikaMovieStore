using System.Data;
using FluentValidation;

namespace Application.Features.Commands.Director.CreateDirector;

public class CreateDirectorCommandValidator: AbstractValidator<CreateDirectorCommandRequest>
{
    public CreateDirectorCommandValidator()
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