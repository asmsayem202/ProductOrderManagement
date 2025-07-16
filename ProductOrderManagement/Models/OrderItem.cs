namespace ProductOrderManagement.Models;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = default!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;

    public int VariantId { get; set; }
    public Variant Variant { get; set; } = default!;

    public int Quantity { get; set; }
}