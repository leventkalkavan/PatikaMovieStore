using MediatR;

namespace Application.Features.Commands.Order.CreateOrder;

public class CreateOrderCommandRequest: IRequest<CreateOrderCommandResponse>
{
    public string CustomerId { get; set; }
    public string MovieId { get; set; }
}