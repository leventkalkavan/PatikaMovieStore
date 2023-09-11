using Application.Features.Commands.AppUser.RefreshTokenLogin;
using MediatR;

namespace Application.Features.Commands.Customer.AppUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
{
    public string RefreshToken { get; set; }
}