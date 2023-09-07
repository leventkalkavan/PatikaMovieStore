using Application.Repositories.Actor;
using MediatR;

namespace Application.Features.Commands.Actor.DeleteActor;

public class DeleteActorCommandHandler: IRequestHandler<DeleteActorCommandRequest,DeleteActorCommandResponse>
{
    private readonly IActorWriteRepository _actorWriteRepository;

    public DeleteActorCommandHandler(IActorWriteRepository actorWriteRepository)
    {
        _actorWriteRepository = actorWriteRepository;
    }

    public async Task<DeleteActorCommandResponse> Handle(DeleteActorCommandRequest request, CancellationToken cancellationToken)
    {
        await _actorWriteRepository.RemoveAsync(request.Id);
        await _actorWriteRepository.SaveAsync();
        return new DeleteActorCommandResponse
        {
            IsSuccess = true
        };
    }
}