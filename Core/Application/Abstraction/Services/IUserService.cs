using Application.Dtos.UserDto;
using Application.Dtos.UserDto.CreateUser;
using Domain.Entities.Identity;

namespace Application.Abstraction.Services;

public interface IUserService
{
     Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
     
     Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
}