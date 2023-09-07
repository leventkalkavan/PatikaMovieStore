using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities;

public class Movie: BaseEntity
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public Director Director { get; set; }
    public List<Actor> Actors { get; set; }
}