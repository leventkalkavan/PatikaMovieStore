using Domain.Entities.Common;

namespace Domain.Entities;

public class Director: BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Movie> Movies { get; set; }
}