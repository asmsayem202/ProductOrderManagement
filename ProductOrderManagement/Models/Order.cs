namespace ProductOrderManagement.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = default!;
    public string CustomerEmail { get; set; } = default!;
    public string CustomerAddress { get; set; } = default!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}