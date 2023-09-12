using Application.Abstraction.Services;
using Application.Repositories.Director;
using MediatR;

namespace Application.Features.Commands.Director.DeleteDirector;

public class DeleteDirectorCommandHandler: IRequestHandler<DeleteDirectorCommandRequest,DeleteDirectorCommandResponse>
{
    private readonly IDirectorWriteRepository _directorWriteRepository;
    private readonly ILoggerService _logger;

    public DeleteDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository, ILoggerService logger)
    {
        _directorWriteRepository = directorWriteRepository;
        _logger = logger;
    }

    public async Task<DeleteDirectorCommandResponse> Handle(DeleteDirectorCommandRequest request, CancellationToken cancellationToken)
    {
        await _directorWriteRepository.RemoveAsync(request.Id);
        await _directorWriteRepository.SaveAsync();
        _logger.Write($"{request.Id}'sine sahip director silindi");
        return new DeleteDirectorCommandResponse
        {
            IsSuccess = true
        };
    }
}