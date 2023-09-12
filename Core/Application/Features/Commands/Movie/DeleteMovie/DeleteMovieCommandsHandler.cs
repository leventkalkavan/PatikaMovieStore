using Application.Abstraction.Services;
using Application.Repositories.Movie;
using MediatR;

namespace Application.Features.Commands.Movie.DeleteMovie;

public class DeleteMovieCommandsHandler: IRequestHandler<DeleteMovieCommandsRequest,DeleteMovieCommandsResponse>
{
    private readonly IMovieWriteRepository _movieWriteRepository;
    private readonly ILoggerService _logger;

    public DeleteMovieCommandsHandler(IMovieWriteRepository movieWriteRepository, ILoggerService logger)
    {
        _movieWriteRepository = movieWriteRepository;
        _logger = logger;
    }

    public async Task<DeleteMovieCommandsResponse> Handle(DeleteMovieCommandsRequest request, CancellationToken cancellationToken)
    {
        await _movieWriteRepository.RemoveAsync(request.Id);
        await _movieWriteRepository.SaveAsync();
        _logger.Write($"{request.Id}'sine sahip movie silindi");
        return new DeleteMovieCommandsResponse
        {
            IsSuccess = true
        };
    }
}