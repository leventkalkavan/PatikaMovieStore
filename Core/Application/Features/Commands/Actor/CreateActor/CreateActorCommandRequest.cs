
using MediatR;

namespace Application.Features.Commands.Actor;

public class CreateActorCommandRequest: IRequest<CreateActorCommandResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MovieId { get; set; }
}