using Application.Dtos.ActorDto;
using Application.Dtos.MovieDto;
using Application.Repositories.Actor;
using Application.Repositories.Movie;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Actor.GetAllActor;

public class GetAllActorQueryHandler: IRequestHandler<GetAllActorQueryRequest,GetAllActorQueryResponse>
{
    private readonly IActorReadRepository _actorReadRepository;

    public GetAllActorQueryHandler(IActorReadRepository actorReadRepository)
    {
        _actorReadRepository = actorReadRepository;
    }

    public async Task<GetAllActorQueryResponse> Handle(GetAllActorQueryRequest request, CancellationToken cancellationToken)
    {
        var actors = _actorReadRepository.Table.Include(h => h.Movies)
            .ToList();
       
        var response = new GetAllActorQueryResponse()
        {
            Actors = actors.Select(actors => new GetAllActorDto()
            {
                Id = actors.Id,
                Name = actors.Name,
                Surname = actors.Surname,
                Movies = actors.Movies.Select(movie => new MovieDto()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Type = movie.Type,
                    Status = movie.Status,
                    Year = movie.Year
                }).ToList()
            }).ToList()
        };
        return response;
    }
}