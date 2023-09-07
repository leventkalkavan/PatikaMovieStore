using Application.Repositories.Actor;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Actor;

public class ActorReadRepository: ReadRepository<Domain.Entities.Actor>, IActorReadRepository
{
    public ActorReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
