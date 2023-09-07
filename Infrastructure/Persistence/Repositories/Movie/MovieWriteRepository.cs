using Application.Repositories.Movie;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Movie;

public class MovieWriteRepository: WriteRepository<Domain.Entities.Movie>, IMovieWriteRepository
{
    public MovieWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}