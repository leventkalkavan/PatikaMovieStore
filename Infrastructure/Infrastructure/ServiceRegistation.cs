using Application.Abstraction.Token;
using Application.Features.Commands.Actor.CreateActor;
using Application.Features.Commands.Actor.UpdateActor;
using Application.Features.Commands.AppUser.CreateCustomer;
using Application.Features.Commands.Director.CreateDirector;
using Application.Features.Commands.Director.UpdateDirector;
using Application.Features.Commands.Movie.CreateMovie;
using FluentValidation.AspNetCore;
using Infrastructure.Attributes;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistation
{
    
    public static void InfrastructureServices(this IServiceCollection services)
    {
        services.AddControllers(options => 
            {
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(configuration => 
            {
                configuration.RegisterValidatorsFromAssemblyContaining<CreateActorCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<CreateDirectorCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<CreateMovieCommandValidator>();
                
                configuration.RegisterValidatorsFromAssemblyContaining<UpdateActorCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<UpdateDirectorCommandValidator>();
            })
            .ConfigureApiBehaviorOptions(o => 
            {
                o.SuppressModelStateInvalidFilter = true;
            });

        services.AddScoped<ITokenHandler, TokenHandler>();
    }
}