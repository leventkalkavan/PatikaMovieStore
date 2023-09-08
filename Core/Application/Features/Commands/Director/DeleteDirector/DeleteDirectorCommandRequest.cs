using MediatR;

namespace Application.Features.Commands.Director.DeleteDirector;

public class DeleteDirectorCommandRequest: IRequest<DeleteDirectorCommandResponse>
{
    public string Id { get; set; }
}