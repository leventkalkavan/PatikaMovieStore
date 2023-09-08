using Application.Repositories.Movie;
using MediatR;

namespace Application.Features.Commands.Movie.DeleteMovie;

public class DeleteMovieCommandsHandler: IRequestHandler<DeleteMovieCommandsRequest,DeleteMovieCommandsResponse>
{
    private readonly IMovieWriteRepository _movieWriteRepository;

    public DeleteMovieCommandsHandler(IMovieWriteRepository movieWriteRepository)
    {
        _movieWriteRepository = movieWriteRepository;
    }

    public async Task<DeleteMovieCommandsResponse> Handle(DeleteMovieCommandsRequest request, CancellationToken cancellationToken)
    {
        await _movieWriteRepository.RemoveAsync(request.Id);
        await _movieWriteRepository.SaveAsync();
        return new DeleteMovieCommandsResponse
        {
            IsSuccess = true
        };
    }
}