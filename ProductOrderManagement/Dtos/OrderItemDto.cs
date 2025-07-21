using ProductOrderManagement.Enums;
namespace ProductOrderManagement.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public string VariantColor { get; set; } = default!;
        public string VariantSpecification { get; set; } = default!;
        public Size VariantSize { get; set; }
        public int Quantity { get; set; }
    }
}