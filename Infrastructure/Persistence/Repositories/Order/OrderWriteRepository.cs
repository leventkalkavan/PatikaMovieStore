using Application.Repositories.Order;
using Persistence.Context;

namespace Persistence.Repositories.Order;

public class OrderWriteRepository: WriteRepository<Domain.Entities.Order>, IOrderWriterRepository
{
    public OrderWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}