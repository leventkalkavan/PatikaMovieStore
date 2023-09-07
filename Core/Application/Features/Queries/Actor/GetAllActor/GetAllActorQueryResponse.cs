using Application.Dtos.ActorDto;

namespace Application.Features.Queries.Actor.GetAllActor;

public class GetAllActorQueryResponse
{
    public List<GetAllActorDto> Actors { get; set; }
}