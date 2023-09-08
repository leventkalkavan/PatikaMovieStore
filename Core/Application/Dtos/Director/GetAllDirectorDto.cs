using Domain.Entities;

namespace Application.Dtos.Director;

public class GetAllDirectorDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Movie> Movies { get; set; }
}