using Application.Abstraction.Services;
using Application.Repositories.Actor;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.Actor.UpdateActor;

public class UpdateActorCommandHandler: IRequestHandler<UpdateActorCommandRequest,UpdateActorCommandResponse>
{
    private readonly IActorWriteRepository _actorWriteRepository;
    private readonly IActorReadRepository _actorReadRepository;
    private readonly ILoggerService _logger;
    public UpdateActorCommandHandler(IActorWriteRepository actorWriteRepository, IActorReadRepository actorReadRepository, ILoggerService logger)
    {
        _actorWriteRepository = actorWriteRepository;
        _actorReadRepository = actorReadRepository;
        _logger = logger;
    }

    public async Task<UpdateActorCommandResponse> Handle(UpdateActorCommandRequest request, CancellationToken cancellationToken)
    {
        var actor = await _actorReadRepository.Table.FindAsync(request.Id);
        if (actor != null)
        {
            actor.Name = request.Name;
            actor.Surname = request.Surname;
        
            await _actorWriteRepository.SaveAsync();
            _logger.Write($"{request.Name} adli director guncellendi");
            return new UpdateActorCommandResponse
            {
                IsSuccess = true
            };
        }
    
        return new UpdateActorCommandResponse
        {
            IsSuccess = false 
        };
    }
}