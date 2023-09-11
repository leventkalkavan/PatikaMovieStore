using Application.DTOs.TokenDto;

namespace Application.Features.Commands.AppUser.Login;

public class LoginCommandResponse
{
}

public class LoginCommandSuccessResponse : LoginCommandResponse
{
    public Token Token { get; set; }
}

public class LoginCommandErrorResponse : LoginCommandResponse
{
    public bool IsSuccess { get; set; }
}