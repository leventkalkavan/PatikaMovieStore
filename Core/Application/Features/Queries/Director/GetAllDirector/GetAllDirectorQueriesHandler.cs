using Application.Abstraction.Services;
using Application.Dtos.ActorDto;
using Application.Dtos.Director;
using Application.Dtos.MovieDto;
using Application.Features.Queries.Actor.GetAllActor;
using Application.Repositories.Director;
using Application.Repositories.Movie;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Director.GetAllDirector;

public class GetAllDirectorQueriesHandler: IRequestHandler<GetAllDirectorQueriesRequest,GetAllDirectorQueriesResponse>
{
    private readonly IDirectorReadRepository _directorReadRepository;
    private IMapper _mapper;
    private readonly ILoggerService _loggerService;

    public GetAllDirectorQueriesHandler(IDirectorReadRepository directorReadRepository, IMapper mapper, ILoggerService loggerService)
    {
        _directorReadRepository = directorReadRepository;
        _mapper = mapper;
        _loggerService = loggerService;
    }

    public async Task<GetAllDirectorQueriesResponse> Handle(GetAllDirectorQueriesRequest request, CancellationToken cancellationToken)
    {
        var directors = _directorReadRepository.Table.Include(h => h.Movies)
            .ToList();
       
        var response = new GetAllDirectorQueriesResponse()
        {
            Directors = directors.Select(directors => new GetAllDirectorDto()
            {
                Id = directors.Id,
                Name = directors.Name,
                Surname = directors.Surname,
                Movies = directors.Movies.Select(movie => new MovieDto()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Status = movie.Status,
                    Type = movie.Type,
                    Year = movie.Year
                }).ToList()
            }).ToList()
        };
        _loggerService.Write("tum directorler getirildii.");
        return _mapper.Map<GetAllDirectorQueriesResponse>(response);
    }
}