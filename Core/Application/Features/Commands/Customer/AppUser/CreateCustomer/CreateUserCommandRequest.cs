using Application.Dtos.UserDto.CreateUser;
using MediatR;

namespace Application.Features.Commands.AppUser.CreateCustomer;

public class CreateUserCommandRequest: IRequest<CreateUserCommandResponse>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}