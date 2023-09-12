using Application.Abstraction.Services;
using Application.Repositories.Actor;
using MediatR;

namespace Application.Features.Commands.Actor.DeleteActor;

public class DeleteActorCommandHandler: IRequestHandler<DeleteActorCommandRequest,DeleteActorCommandResponse>
{
    private readonly IActorWriteRepository _actorWriteRepository;
    private readonly ILoggerService _logger;
    public DeleteActorCommandHandler(IActorWriteRepository actorWriteRepository, ILoggerService logger)
    {
        _actorWriteRepository = actorWriteRepository;
        _logger = logger;
    }

    public async Task<DeleteActorCommandResponse> Handle(DeleteActorCommandRequest request, CancellationToken cancellationToken)
    {
        await _actorWriteRepository.RemoveAsync(request.Id);
        await _actorWriteRepository.SaveAsync();
        _logger.Write($"{request.Id}'sine sahip actor silindi");
        return new DeleteActorCommandResponse
        {
            IsSuccess = true
        };
    }
}