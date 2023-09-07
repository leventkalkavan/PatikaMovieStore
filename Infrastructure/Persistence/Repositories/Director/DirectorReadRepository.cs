using Application.Repositories.Director;
using Persistence.Context;

namespace Persistence.Repositories.Director;

public class DirectorReadRepository: ReadRepository<Domain.Entities.Director>, IDirectorReadRepository
{
    public DirectorReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}