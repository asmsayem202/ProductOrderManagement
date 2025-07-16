namespace ProductOrderManagement.Dtos;

public class CreateOrderItemDto
{
    public int ProductId { get; set; }
    public int VariantId { get; set; }
    public int Quantity { get; set; }
}