using Application.Repositories.Director;
using MediatR;

namespace Application.Features.Commands.Director.UpdateDirector;

public class UpdateDirectorCommandHandler: IRequestHandler<UpdateDirectorCommandRequest,UpdateDirectorCommandResponse>
{
    private readonly IDirectorWriteRepository _directorWriteRepository;

    public UpdateDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository)
    {
        _directorWriteRepository = directorWriteRepository;
    }

    public async Task<UpdateDirectorCommandResponse> Handle(UpdateDirectorCommandRequest request, CancellationToken cancellationToken)
    {
        var director = await _directorWriteRepository.Table.FindAsync(request.Id);
        if (director != null)
        {
            director.Name = request.Name;
            director.Surname = request.Surname;
        }
        return new UpdateDirectorCommandResponse
        {
            IsSuccess = true
        };
    }
}