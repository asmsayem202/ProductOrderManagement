namespace ProductOrderManagement.Dtos;

public class CreateOrderDto
{
    public string CustomerName { get; set; } = default!;
    public string CustomerEmail { get; set; } = default!;
    public string CustomerAddress { get; set; } = default!;
    public List<CreateOrderItemDto> Items { get; set; } = new();
}