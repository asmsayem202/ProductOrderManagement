using ProductOrderManagement.Enums;

namespace ProductOrderManagement.Models;

public class Variant
{
    public int Id { get; set; }
    public string Color { get; set; } = default!;
    public string Specification { get; set; } = default!;
    public Size Size { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;
}