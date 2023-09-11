using Application.Dtos.ActorDto;
using Application.Dtos.Director;

namespace Application.Features.Queries.Director.GetAllDirector;

public class GetAllDirectorQueriesResponse
{
    public List<GetAllDirectorDto> Directors { get; set; }
}