using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Customer.AppUser.DeleteCustomer;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommandRequest,DeleteUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

    public DeleteUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
    {
        _userManager = userManager;
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
        DeleteUserCommandResponse response = new() { IsSuccess = result.Succeeded };
        return response;
    }
}