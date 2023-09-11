namespace Application.Abstraction.Services;

public interface IAuthService
{
    Task<DTOs.TokenDto.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
    Task<DTOs.TokenDto.Token> RefreshTokenLoginAsync(string refreshToken);
}