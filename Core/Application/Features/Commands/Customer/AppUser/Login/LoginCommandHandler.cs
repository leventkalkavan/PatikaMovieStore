using Application.Abstraction.Services;
using MediatR;

namespace Application.Features.Commands.AppUser.Login;

public class LoginCommandHandler: IRequestHandler<LoginCommandRequest,LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.NameOrEmail, request.Password,900);
        return new LoginCommandSuccessResponse()
        {
            Token = token
        };
    }
}