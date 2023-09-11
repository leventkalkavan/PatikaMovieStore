using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class AppUser: IdentityUser
{
    public List<Order> Orders { get; set; } 
    public string? FavoriteFilmType { get; set; } 
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenTime { get; set; }
}