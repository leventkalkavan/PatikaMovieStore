using Application.Abstraction.Services;
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
    private readonly ILoggerService _loggerService;
    IMapper _mapper;
    public GetAllActorQueryHandler(IActorReadRepository actorReadRepository, IMapper mapper, ILoggerService loggerService)
    {
        _actorReadRepository = actorReadRepository;
        _mapper = mapper;
        _loggerService = loggerService;
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
        _loggerService.Write("tum actorler listelendi.");
        var response = new GetAllActorQueryResponse
        {
            Actors = actorDtos
        };

        return _mapper.Map<GetAllActorQueryResponse>(response);
    }

}