using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Customer.AppRole.CreateRole;

public class AppRoleCommandHandler: IRequestHandler<AppRoleCommandRequest,AppRoleCommandResponse>
{
    public RoleManager<Domain.Entities.Identity.AppRole> _roleManager;

    public AppRoleCommandHandler(RoleManager<Domain.Entities.Identity.AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<AppRoleCommandResponse> Handle(AppRoleCommandRequest request, CancellationToken cancellationToken)
    {
        IdentityResult result = await _roleManager.CreateAsync(new Domain.Entities.Identity.AppRole() { Name = request.Name});
        if (result.Succeeded)
        {
            return new AppRoleCommandResponse()
            {
                IsSuccess = true
            };
        }

        return new AppRoleCommandResponse()
        {
            IsSuccess = false
        };
    }
}