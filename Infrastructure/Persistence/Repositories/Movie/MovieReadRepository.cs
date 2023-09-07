using Application.Repositories;
using Application.Repositories.Movie;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Movie;

public class MovieReadRepository: ReadRepository<Domain.Entities.Movie>, IMovieReadRepository
{
    public MovieReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}