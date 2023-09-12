using Application.Abstraction.Services;
using Application.Repositories.Order;
using MediatR;

namespace Application.Features.Commands.Order.DeleteOrder;

public class DeleteOrderCommandHandler: IRequestHandler<DeleteOrderCommandRequest,DeleteOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly ILoggerService _logger;

    public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository, ILoggerService logger)
    {
        _orderWriteRepository = orderWriteRepository;
        _logger = logger;
    }

    public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        await _orderWriteRepository.RemoveAsync(request.Id);
        await _orderWriteRepository.SaveAsync();
        _logger.Write($"{request.Id}'sine sahip order silindi");
        return new DeleteOrderCommandResponse()
        {
            IsSuccess = true
        };
    }
}