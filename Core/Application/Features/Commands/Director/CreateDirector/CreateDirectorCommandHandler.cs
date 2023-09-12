using Application.Abstraction.Services;
using Application.Repositories.Director;
using MediatR;

namespace Application.Features.Commands.Director.CreateDirector;

public class CreateDirectorCommandHandler: IRequestHandler<CreateDirectorCommandRequest,CreateDirectorCommandResponse>
{
    private readonly IDirectorWriteRepository _directorWriteRepository;
    private readonly ILoggerService _logger;

    public CreateDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository, ILoggerService logger)
    {
        _directorWriteRepository = directorWriteRepository;
        _logger = logger;
    }

    public async Task<CreateDirectorCommandResponse> Handle(CreateDirectorCommandRequest request, CancellationToken cancellationToken)
    {
        await _directorWriteRepository.AddAsync(new Domain.Entities.Director()
        {
            Name = request.Name,
            Surname = request.Surname
        });
        await _directorWriteRepository.SaveAsync();
        _logger.Write($"{request.Name} adli director eklendi");
        return new CreateDirectorCommandResponse()
        {
            IsSuccess = true
        };
    }
}