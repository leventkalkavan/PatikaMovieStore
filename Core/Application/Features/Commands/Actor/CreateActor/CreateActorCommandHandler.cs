
using Application.Repositories.Actor;
using MediatR;

namespace Application.Features.Commands.Actor;

public class CreateActorCommandHandler: IRequestHandler<CreateActorCommandRequest,CreateActorCommandResponse>
{
    private readonly IActorWriteRepository _actorWriteRepository;

    public CreateActorCommandHandler(IActorWriteRepository actorWriteRepository)
    {
        _actorWriteRepository = actorWriteRepository;
    }

    public async Task<CreateActorCommandResponse> Handle(CreateActorCommandRequest request, CancellationToken cancellationToken)
    {
        var actor = await _actorWriteRepository.AddAsync(new Domain.Entities.Actor()
        {
            Name = request.Name,
            Surname = request.Surname
        });
        await _actorWriteRepository.SaveAsync();
        return new CreateActorCommandResponse()
        {
            IsSuccess = true
        };
    }
}