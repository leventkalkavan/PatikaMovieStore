using FluentValidation;

namespace Application.Features.Commands.Customer.AppUser.DeleteCustomer;

public class DeleteUserCommandValidator: AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("idyi kontrol et");
    }
}