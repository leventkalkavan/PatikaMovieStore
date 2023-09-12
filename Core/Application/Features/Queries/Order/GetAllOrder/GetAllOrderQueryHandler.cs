using Application.Abstraction.Services;
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
    private readonly ILoggerService _loggerService;

    public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper, ILoggerService loggerService)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
        _loggerService = loggerService;
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
        _loggerService.Write("tum orderlar getirildii.");
        return _mapper.Map<GetAllOrderQueryResponse>(response);
    }
}