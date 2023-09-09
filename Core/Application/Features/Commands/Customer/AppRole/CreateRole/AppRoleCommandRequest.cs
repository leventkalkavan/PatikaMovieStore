using MediatR;

namespace Application.Features.Commands.Customer.AppRole.CreateRole;

public class AppRoleCommandRequest: IRequest<AppRoleCommandResponse>
{
    public string Name { get; set; }
}