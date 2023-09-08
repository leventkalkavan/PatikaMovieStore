using Application.Features.Commands.Director.DeleteDirector;
using MediatR;

namespace Application.Features.Commands.Movie.DeleteMovie;

public class DeleteMovieCommandsRequest: IRequest<DeleteMovieCommandsResponse>
{
    public string Id { get; set; }
}