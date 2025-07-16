namespace ProductOrderManagement.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = default!;
        public string CustomerEmail { get; set; } = default!;
        public string CustomerAddress { get; set; } = default!;
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
