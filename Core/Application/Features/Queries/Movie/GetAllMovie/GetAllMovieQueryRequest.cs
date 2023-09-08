using Application.Dtos.MovieDto;
using MediatR;

namespace Application.Features.Queries.Movie.GetAllMovie;

public class GetAllMovieQueryRequest: IRequest<GetAllMovieQueryResponse>
{
}