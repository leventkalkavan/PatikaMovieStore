using Domain.Entities.Common;

namespace Domain.Entities;

public class Actor: BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MovieId { get; set; }
    
    public ICollection<Movie> Movies { get; set; }
}