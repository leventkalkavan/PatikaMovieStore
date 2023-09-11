using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Movie.CreateMovie;

public class CreateMovieCommandRequest: IRequest<CreateMovieCommandResponse>
{
    public string Name { get; set; }
    public int Year { get; set; }
    public bool Status { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public string DirectorId { get; set; }
}