using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {}

    // private DbSet<Entity> Entities { get; set; }
}