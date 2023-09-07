using Application.Repositories.Order;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Order;

public class OrderReadRepository: ReadRepository<Domain.Entities.Order>, IOrderReadRepository
{
    public OrderReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}