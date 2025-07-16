using ProductOrderManagement.Enums;

namespace ProductOrderManagement.Dtos;

public class VariantDto
{
    public int? Id { get; set; }
    public string Color { get; set; } = default!;
    public string Specification { get; set; } = default!;
    public Size Size { get; set; }
}