using Application.Repositories.Actor;
using Persistence.Context;

namespace Persistence.Repositories.Actor;

public class ActorWriteRepository: WriteRepository<Domain.Entities.Actor>, IActorWriteRepository
{
    public ActorWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}