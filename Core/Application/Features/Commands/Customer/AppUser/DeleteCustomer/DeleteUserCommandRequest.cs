using MediatR;

namespace Application.Features.Commands.Customer.AppUser.DeleteCustomer;

public class DeleteUserCommandRequest: IRequest<DeleteUserCommandResponse>
{
    public string Id { get; set; }
}