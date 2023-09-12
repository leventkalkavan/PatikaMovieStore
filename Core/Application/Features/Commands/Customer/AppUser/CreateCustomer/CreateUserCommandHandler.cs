using Application.Abstraction.Services;
using Application.Dtos.UserDto.CreateUser;
using MediatR;

namespace Application.Features.Commands.AppUser.CreateCustomer;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private readonly IUserService _userService;
    private readonly ILoggerService _logger;
    public CreateUserCommandHandler(IUserService userService, ILoggerService logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateAsync(new CreateUserDto()
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            FavoriteFilmType = request.FavoriteFilmType
        });
        _logger.Write($"{request.Username} adli customer eklendi");
        return new CreateUserCommandResponse()
        {
            IsSuccess = user.IsSuccess
        }; 
    }
}