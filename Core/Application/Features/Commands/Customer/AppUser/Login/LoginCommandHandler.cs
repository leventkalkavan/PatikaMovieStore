using Application.Abstraction.Services;
using MediatR;

namespace Application.Features.Commands.AppUser.Login;

public class LoginCommandHandler: IRequestHandler<LoginCommandRequest,LoginCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly ILoggerService _logger;

    public LoginCommandHandler(IAuthService authService, ILoggerService logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.NameOrEmail, request.Password,900);
        _logger.Write($"{request.NameOrEmail} adli customer giris yapti");
        return new LoginCommandSuccessResponse()
        {
            Token = token
        };
    }
}