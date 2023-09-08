using MediatR;

namespace Application.Features.Commands.Director.CreateDirector;

public class CreateDirectorCommandRequest: IRequest<CreateDirectorCommandResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}