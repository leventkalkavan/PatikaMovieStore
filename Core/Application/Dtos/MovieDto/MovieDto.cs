using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Application.Dtos.MovieDto;

public class MovieDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
}