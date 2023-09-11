
using Application.Abstraction.Services;
using Application.Abstraction.Token;
using Application.DTOs.TokenDto;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace Persistence.Services;

public class AuthService: IAuthService
{
    private readonly UserManager<AppUser?> _userManager;
    private readonly SignInManager<AppUser?> _signInManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IUserService _userService;

    public AuthService(UserManager<AppUser?> userManager, SignInManager<AppUser?> signInManager, ITokenHandler tokenHandler, IUserService userService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
    }
    public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
    {
        AppUser? user = await _userManager.FindByNameAsync(usernameOrEmail);
        if (user == null)
            user = await _userManager.FindByEmailAsync(usernameOrEmail);

        if (user == null)
            throw new Exception();

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (result.Succeeded) //Authentication başarılı!
        {
            Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
            await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
            return token;
        }
        throw new Exception();
    }

    public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
    {
        AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user != null && user?.RefreshTokenTime > DateTime.UtcNow)
        {
            Token token = _tokenHandler.CreateAccessToken(15, user);
            await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 900);
            return token;
        }
        else
            throw new Exception();
    }
}