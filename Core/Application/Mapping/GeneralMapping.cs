using Application.Features.Queries.Actor.GetAllActor;
using Application.Features.Queries.Order.GetAllOrder;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class GeneralMapping: Profile
{
    public GeneralMapping()
    {
        CreateMap<Actor, GetAllActorQueryResponse>()
            .ReverseMap();
        CreateMap<Director, GetAllActorQueryResponse>()
            .ReverseMap();
        CreateMap<Movie, GetAllActorQueryResponse>()
            .ReverseMap();
        CreateMap<Order, GetAllOrderQueryResponse>()
            .ReverseMap();
    }
}