using Domain.Entities;

namespace Application.Dtos.ActorDto;

public class ActorDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<MovieDto.MovieDto> Movies { get; set; }
}