using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,string>
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {}

     public DbSet<Actor> Actors { get; set; }
     public DbSet<Director> Directors { get; set; }
     public DbSet<Movie> Movies { get; set; }
     public DbSet<Order> Orders { get; set; }
}