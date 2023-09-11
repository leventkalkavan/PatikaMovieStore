using MediatR;

namespace Application.Features.Commands.AppUser.Login;

public class LoginCommandRequest: IRequest<LoginCommandResponse>
{
    public string NameOrEmail { get; set; }
    public string Password { get; set; }
}