using Application.Abstraction.Services;
using Application.Dtos.UserDto.CreateUser;
using MediatR;

namespace Application.Features.Commands.AppUser.CreateCustomer;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateAsync(new CreateUserDto()
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password
        });
        return new CreateUserCommandResponse()
        {
            IsSuccess = user.IsSuccess
        }; 
    }
}