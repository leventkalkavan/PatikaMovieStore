    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Dtos.ActorDto;
    using Application.Dtos.MovieDto;
    using Application.Repositories.Actor;
    using Application.Repositories.Movie;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    namespace Application.Features.Queries.Movie.GetAllMovie
    {
        public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQueryRequest, GetAllMovieQueryResponse>
        {
            private readonly IMovieReadRepository _movieReadRepository;
            private readonly IActorReadRepository _actorReadRepository;

            public GetAllMovieQueryHandler(IMovieReadRepository movieReadRepository, IActorReadRepository actorReadRepository)
            {
                _movieReadRepository = movieReadRepository;
                _actorReadRepository = actorReadRepository;
            }

            public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQueryRequest request, CancellationToken cancellationToken)
            {
                var movies = await _movieReadRepository.Table
                    .Include(movie => movie.Actors)
                    .ToListAsync();

                var movieDtos = movies.Select(movie => new MovieDto
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Price = movie.Price,
                    Year = movie.Year,
                    Type = movie.Type
                }).ToList();

                var response = new GetAllMovieQueryResponse
                {
                    Movies = movieDtos
                };

                return response;
            }


        }
    }