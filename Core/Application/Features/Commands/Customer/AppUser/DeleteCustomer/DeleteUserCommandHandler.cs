using Application.Abstraction.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Customer.AppUser.DeleteCustomer;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommandRequest,DeleteUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private readonly ILoggerService _logger;

    public DeleteUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ILoggerService logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        var res = await _userManager.FindByIdAsync(request.Id);
        if (res == null)
            return new DeleteUserCommandResponse()
            {
                IsSuccess = false
            };
        var result = await _userManager.DeleteAsync(res);
        _logger.Write($"{request.Id}'sine sahip customer silindi");
        DeleteUserCommandResponse response = new() { IsSuccess = result.Succeeded };
        return response;
    }
}