using Application.Dtos.OrderDto;
using Application.Repositories.Order;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Order.GetAllOrder;

public class GetAllOrderQueryHandler: IRequestHandler<GetAllOrderQueryRequest,GetAllOrderQueryResponse>
{
    private readonly IOrderReadRepository _orderReadRepository;
    private IMapper _mapper;

    public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }

    public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        var orders = await _orderReadRepository.Table
            .Include(order => order.Customer)
            .ToListAsync();

        var orderDtos = orders.Select(order => new GetAllOrderDto()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            MovieId = order.MovieId,
            HiringDateTime = order.HiringDateTime,
        }).ToList();

        var response = new GetAllOrderQueryResponse()
        {
            Orders = orderDtos
        };

        return _mapper.Map<GetAllOrderQueryResponse>(response);
    }
}