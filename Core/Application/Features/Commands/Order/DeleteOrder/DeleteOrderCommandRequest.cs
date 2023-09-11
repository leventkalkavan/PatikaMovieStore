using MediatR;

namespace Application.Features.Commands.Order.DeleteOrder;

public class DeleteOrderCommandRequest: IRequest<DeleteOrderCommandResponse>
{
    public string Id { get; set; }
}