using Application.Abstraction.Services;
using Application.Dtos.UserDto.CreateUser;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Services;

public class UserService: IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto model)
    {
        var result = await _userManager.CreateAsync(new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = model.Username,
            Email = model.Email
        }, model.Password);
        CreateUserResponseDto response = new() { IsSuccess = result.Succeeded };
        return response;
    }
}