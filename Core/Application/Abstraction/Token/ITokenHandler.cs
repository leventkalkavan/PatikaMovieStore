using Domain.Entities.Identity;

namespace Application.Abstraction.Token;

public interface ITokenHandler
{
    DTOs.TokenDto.Token CreateAccessToken(int second,AppUser user);
    string CreateRefreshToken();
}