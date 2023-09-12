using Application.Abstraction.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Features.Commands.Customer.AppRole.CreateRole;

public class AppRoleCommandHandler: IRequestHandler<AppRoleCommandRequest,AppRoleCommandResponse>
{
    public readonly RoleManager<Domain.Entities.Identity.AppRole> _roleManager;
    private readonly ILoggerService _logger;

    public AppRoleCommandHandler(RoleManager<Domain.Entities.Identity.AppRole> roleManager, ILoggerService logger)
    {
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task<AppRoleCommandResponse> Handle(AppRoleCommandRequest request, CancellationToken cancellationToken)
    {
        IdentityResult result = await _roleManager.CreateAsync(new Domain.Entities.Identity.AppRole() { Name = request.Name});
        if (result.Succeeded)
        {
            _logger.Write($"{request.Name} adli rol eklendi");
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