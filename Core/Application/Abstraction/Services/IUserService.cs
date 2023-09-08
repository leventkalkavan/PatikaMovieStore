using Application.Dtos.UserDto;
using Application.Dtos.UserDto.CreateUser;

namespace Application.Abstraction.Services;

public interface IUserService
{
     Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
}