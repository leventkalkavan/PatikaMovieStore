using Application.Dtos.OrderDto;

namespace Application.Features.Queries.Order.GetAllOrder;

public class GetAllOrderQueryResponse
{
    public List<GetAllOrderDto> Orders { get; set; }
}