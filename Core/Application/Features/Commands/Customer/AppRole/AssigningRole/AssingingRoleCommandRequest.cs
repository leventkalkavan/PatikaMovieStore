using MediatR;

namespace Application.Features.Commands.Customer.AppRole.AssigningRole;

public class AssingingRoleCommandRequest: IRequest<AssingingRoleCommandResponse>
{
    public string UserId { get; set; }
    public string RoleId { get; set; }
}