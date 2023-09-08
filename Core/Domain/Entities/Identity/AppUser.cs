using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class AppUser: IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Movie> BuyFilms { get; set; }
    public string FavoriteFilmType { get; set; }
}