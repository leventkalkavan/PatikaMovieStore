using Application.Repositories.Order;
using MediatR;

namespace Application.Features.Commands.Order.DeleteOrder;

public class DeleteOrderCommandHandler: IRequestHandler<DeleteOrderCommandRequest,DeleteOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        await _orderWriteRepository.RemoveAsync(request.Id);
        await _orderWriteRepository.SaveAsync();
        return new DeleteOrderCommandResponse()
        {
            IsSuccess = true
        };
    }
}