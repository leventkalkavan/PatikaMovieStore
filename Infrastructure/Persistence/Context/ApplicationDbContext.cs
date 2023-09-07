using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {}

     public DbSet<Actor> Actors { get; set; }
     public DbSet<Director> Directors { get; set; }
     public DbSet<Movie> Movies { get; set; }
     public DbSet<Order> Orders { get; set; }
}