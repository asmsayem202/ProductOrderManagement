namespace ProductOrderManagement.Dtos;

public class OrderDetailsDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = default!;
    public string CustomerEmail { get; set; } = default!;
    public string CustomerAddress { get; set; } = default!;
    public DateTime OrderDate { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public string ProductName { get; set; } = default!;
    public string VariantSpec { get; set; } = default!;
    public int Quantity { get; set; }
}