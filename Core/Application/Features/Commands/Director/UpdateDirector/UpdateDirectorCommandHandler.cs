using Application.Abstraction.Services;
using Application.Repositories.Director;
using MediatR;

namespace Application.Features.Commands.Director.UpdateDirector;

public class UpdateDirectorCommandHandler: IRequestHandler<UpdateDirectorCommandRequest,UpdateDirectorCommandResponse>
{
    private readonly IDirectorWriteRepository _directorWriteRepository;
    private readonly ILoggerService _logger;

    public UpdateDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository, ILoggerService logger)
    {
        _directorWriteRepository = directorWriteRepository;
        _logger = logger;
    }

    public async Task<UpdateDirectorCommandResponse> Handle(UpdateDirectorCommandRequest request, CancellationToken cancellationToken)
    {
        var director = await _directorWriteRepository.Table.FindAsync(request.Id);
        if (director != null)
        {
            director.Name = request.Name;
            director.Surname = request.Surname;
        }
        _logger.Write($"{request.Name} adli director guncellendi");
        return new UpdateDirectorCommandResponse
        {
            IsSuccess = true
        };
    }
}