using Application.Abstraction.Services;
using Application.Abstraction.Token;
using Application.Features.Commands.Actor.CreateActor;
using Application.Repositories.Actor;
using Application.Repositories.Director;
using Application.Repositories.Movie;
using Application.Repositories.Order;
using Domain.Entities.Identity;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.Actor;
using Persistence.Repositories.Director;
using Persistence.Repositories.Movie;
using Persistence.Repositories.Order;
using Persistence.Services;

namespace Persistence;

public static class ServiceRegistation
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString));
        
        services.AddIdentity<AppUser,AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>();
        
        services.AddScoped<IActorWriteRepository, ActorWriteRepository>();
        services.AddScoped<IActorReadRepository, ActorReadRepository>();
        
        services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
        services.AddScoped<IMovieReadRepository, MovieReadRepository>();
        
        services.AddScoped<IDirectorReadRepository, DirectorReadRepository>();
        services.AddScoped<IDirectorWriteRepository, DirectorWriteRepository>();
        
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<IAuthService, AuthService>();
        
    }
}