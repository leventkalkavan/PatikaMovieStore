namespace Application.Dtos.OrderDto;

public class GetAllOrderDto
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string MovieId { get; set; }
    public DateTime HiringDateTime { get; set; }
}