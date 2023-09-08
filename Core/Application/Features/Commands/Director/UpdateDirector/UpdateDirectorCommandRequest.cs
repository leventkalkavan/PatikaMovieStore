using MediatR;

namespace Application.Features.Commands.Director.UpdateDirector;

public class UpdateDirectorCommandRequest: IRequest<UpdateDirectorCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}