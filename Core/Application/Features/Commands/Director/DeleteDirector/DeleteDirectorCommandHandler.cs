using Application.Repositories.Director;
using MediatR;

namespace Application.Features.Commands.Director.DeleteDirector;

public class DeleteDirectorCommandHandler: IRequestHandler<DeleteDirectorCommandRequest,DeleteDirectorCommandResponse>
{
    private readonly IDirectorWriteRepository _directorWriteRepository;

    public DeleteDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository)
    {
        _directorWriteRepository = directorWriteRepository;
    }

    public async Task<DeleteDirectorCommandResponse> Handle(DeleteDirectorCommandRequest request, CancellationToken cancellationToken)
    {
        await _directorWriteRepository.RemoveAsync(request.Id);
        await _directorWriteRepository.SaveAsync();
        return new DeleteDirectorCommandResponse
        {
            IsSuccess = true
        };
    }
}