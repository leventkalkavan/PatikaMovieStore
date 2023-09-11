using System.Reflection;
using Application.Features.Commands.Actor.CreateActor;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(ServiceRegistration));
        collection.AddHttpClient();
        collection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}