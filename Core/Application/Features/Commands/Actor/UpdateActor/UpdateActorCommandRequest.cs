using MediatR;

namespace Application.Features.Commands.Actor.UpdateActor;

public class UpdateActorCommandRequest : IRequest<UpdateActorCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}