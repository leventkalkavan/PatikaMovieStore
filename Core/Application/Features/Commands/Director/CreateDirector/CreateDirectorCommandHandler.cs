using Application.Repositories.Director;
using MediatR;

namespace Application.Features.Commands.Director.CreateDirector;

public class CreateDirectorCommandHandler: IRequestHandler<CreateDirectorCommandRequest,CreateDirectorCommandResponse>
{
    private readonly IDirectorWriteRepository _directorWriteRepository;

    public CreateDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository)
    {
        _directorWriteRepository = directorWriteRepository;
    }

    public async Task<CreateDirectorCommandResponse> Handle(CreateDirectorCommandRequest request, CancellationToken cancellationToken)
    {
        await _directorWriteRepository.AddAsync(new Domain.Entities.Director()
        {
            Name = request.Name,
            Surname = request.Surname
        });
        await _directorWriteRepository.SaveAsync();
        return new CreateDirectorCommandResponse()
        {
            IsSuccess = true
        };
    }
}