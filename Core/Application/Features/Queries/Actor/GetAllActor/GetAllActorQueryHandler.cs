using Application.Dtos.ActorDto;
using Application.Dtos.MovieDto;
using Application.Repositories.Actor;
using Application.Repositories.Movie;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Actor.GetAllActor;

public class GetAllActorQueryHandler: IRequestHandler<GetAllActorQueryRequest,GetAllActorQueryResponse>
{
    private readonly IActorReadRepository _actorReadRepository;

    IMapper _mapper;
    public GetAllActorQueryHandler(IActorReadRepository actorReadRepository, IMapper mapper)
    {
        _actorReadRepository = actorReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllActorQueryResponse> Handle(GetAllActorQueryRequest request, CancellationToken cancellationToken)
    {
        var actors = await _actorReadRepository.Table
            .Include(actor => actor.Movies)
            .ToListAsync();
        var actorDtos = actors.Select(actor => new GetAllActorDto
        {
            Id = actor.Id,
            Name = actor.Name,
            Surname = actor.Surname,
            MoveId = actor.MovieId
        }).ToList();
        var response = new GetAllActorQueryResponse
        {
            Actors = actorDtos
        };

        return _mapper.Map<GetAllActorQueryResponse>(response);
    }

}