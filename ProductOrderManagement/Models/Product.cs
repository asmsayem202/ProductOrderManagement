using ProductOrderManagement.Enums;

namespace ProductOrderManagement.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public ProductType Type { get; set; }

    public ICollection<Variant> Variants { get; set; } = new List<Variant>();
}