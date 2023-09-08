using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos.MovieDto;
using Application.Repositories.Movie;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Movie.GetAllMovie
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQueryRequest, GetAllMovieQueryResponse>
    {
        private readonly IMovieReadRepository _movieReadRepository;

        public GetAllMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }

        public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQueryRequest request, CancellationToken cancellationToken)
        {
            var movies = await _movieReadRepository.Table.ToListAsync();
            var movieDtos = movies.Select(movie => new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
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