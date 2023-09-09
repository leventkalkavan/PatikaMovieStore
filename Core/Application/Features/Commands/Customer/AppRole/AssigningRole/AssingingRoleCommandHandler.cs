using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Customer.AppRole.AssigningRole;

public class AssingingRoleCommandHandler : IRequestHandler<AssingingRoleCommandRequest, AssingingRoleCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;

    public AssingingRoleCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager,
        RoleManager<Domain.Entities.Identity.AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AssingingRoleCommandResponse> Handle(AssingingRoleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        var role = await _roleManager.FindByIdAsync(request.RoleId);
        if (user != null)
        {
            if (role != null)
            {
                if (role.Name != null)
                {
                    var result = await _userManager.AddToRoleAsync(user, role.Name);
                    if (result.Succeeded)
                    {
                        return new()
                        {
                            IsSuccess = true
                        };
                    }
                }
            }
        }
        return new()
        {
            IsSuccess = false
        };
    }
}