using Application.Abstraction.Token;
using Application.Features.Commands.Actor.CreateActor;
using Application.Features.Commands.Actor.DeleteActor;
using Application.Features.Commands.Actor.UpdateActor;
using Application.Features.Commands.AppUser.CreateCustomer;
using Application.Features.Commands.Customer.AppUser.DeleteCustomer;
using Application.Features.Commands.Director.CreateDirector;
using Application.Features.Commands.Director.DeleteDirector;
using Application.Features.Commands.Director.UpdateDirector;
using Application.Features.Commands.Movie.CreateMovie;
using Application.Features.Commands.Movie.DeleteMovie;
using Application.Features.Commands.Order.CreateOrder;
using Application.Features.Commands.Order.DeleteOrder;
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
                configuration.RegisterValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();
                
                configuration.RegisterValidatorsFromAssemblyContaining<UpdateActorCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<UpdateDirectorCommandValidator>();
                
                configuration.RegisterValidatorsFromAssemblyContaining<DeleteActorCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<DeleteDirectorCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<DeleteMovieCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<DeleteUserCommandValidator>();
                configuration.RegisterValidatorsFromAssemblyContaining<DeleteOrderCommandValidator>();
            })
            .ConfigureApiBehaviorOptions(o => 
            {
                o.SuppressModelStateInvalidFilter = true;
            });

        services.AddScoped<ITokenHandler, TokenHandler>();
    }
}