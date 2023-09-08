using Application.Dtos.MovieDto;

namespace Application.Features.Queries.Movie.GetAllMovie;

public class GetAllMovieQueryResponse
{
    public List<MovieDto> Movies { get; set; }
}