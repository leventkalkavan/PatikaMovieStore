using Domain.Entities;

namespace Application.Dtos.MovieDto;

public class GetAllMovieDto
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
    public Domain.Entities.Director Director { get; set; }
    public List<Actor> Actors { get; set; }
}