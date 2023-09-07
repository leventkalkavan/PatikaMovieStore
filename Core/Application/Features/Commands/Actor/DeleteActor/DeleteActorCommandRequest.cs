using MediatR;

namespace Application.Features.Commands.Actor.DeleteActor;

public class DeleteActorCommandRequest: IRequest<DeleteActorCommandResponse>
{
    public string Id { get; set; }
}