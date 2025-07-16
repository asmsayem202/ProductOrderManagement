using ProductOrderManagement.Enums;

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
    public int Id { get; set; }
    public string ProductName { get; set; } = default!;
    public string VariantColor { get; set; } = default!;
    public string VariantSpecification { get; set; } = default!;
    public Size VariantSize { get; set; }
    public int Quantity { get; set; }
}