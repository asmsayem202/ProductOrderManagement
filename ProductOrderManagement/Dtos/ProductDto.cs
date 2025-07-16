using ProductOrderManagement.Enums;

namespace ProductOrderManagement.Dtos;

public class ProductDto
{
    public string Name { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public ProductType Type { get; set; }
    public List<VariantDto> Variants { get; set; } = new();
}