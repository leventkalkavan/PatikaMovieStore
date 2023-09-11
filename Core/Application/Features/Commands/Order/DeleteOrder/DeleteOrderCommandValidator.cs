using FluentValidation;

namespace Application.Features.Commands.Order.DeleteOrder;

public class DeleteOrderCommandValidator: AbstractValidator<DeleteOrderCommandRequest>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("idyi kontrol et");
    }
}