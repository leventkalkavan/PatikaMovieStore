using Application.Abstraction.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Customer.AppRole.AssigningRole;

public class AssingingRoleCommandHandler : IRequestHandler<AssingingRoleCommandRequest, AssingingRoleCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;
    private readonly ILoggerService _logger;

    public AssingingRoleCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager,
        RoleManager<Domain.Entities.Identity.AppRole> roleManager, ILoggerService logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
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
                        _logger.Write($"{request.RoleId}'sine sahip rol, {request.UserId}'sine sahip usera atandi");
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