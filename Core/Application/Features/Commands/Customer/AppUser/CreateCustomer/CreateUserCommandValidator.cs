using FluentValidation;

namespace Application.Features.Commands.AppUser.CreateCustomer;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username).NotNull().WithMessage("The name should not be empty.")
            .MaximumLength(20)
            .MinimumLength(2)
            .WithMessage("The 'username' value should be in the number of characters from 3 to 20.");
        RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("adam gibi mail gir");
        RuleFor(x => x.Password).NotNull().WithMessage("sifreni duzgun gir (buyuk harf,kucuk harf,rakam,noktalama isareti)");
    }
}