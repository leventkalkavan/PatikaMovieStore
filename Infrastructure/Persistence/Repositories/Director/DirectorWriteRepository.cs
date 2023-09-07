using Application.Repositories.Director;
using Persistence.Context;

namespace Persistence.Repositories.Director;

public class DirectorWriteRepository: WriteRepository<Domain.Entities.Director>, IDirectorWriteRepository
{
    public DirectorWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}