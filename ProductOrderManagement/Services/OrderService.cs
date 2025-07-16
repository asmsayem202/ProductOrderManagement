using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.Data;
using ProductOrderManagement.Dtos;
using ProductOrderManagement.Models;
using ProductOrderManagement.Services.Interfaces;

namespace ProductOrderManagement.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _context.Orders.Include(o => o.Items).ThenInclude(i => i.Product)
                                 .Include(o => o.Items).ThenInclude(i => i.Variant).ToListAsync();

    public async Task<Order?> GetByIdAsync(int id)
        => await _context.Orders.Include(o => o.Items).ThenInclude(i => i.Product)
                                 .Include(o => o.Items).ThenInclude(i => i.Variant)
                                 .FirstOrDefaultAsync(o => o.Id == id);

    public async Task<Order> CreateAsync(CreateOrderDto dto)
    {
        var order = new Order
        {
            CustomerName = dto.CustomerName,
            CustomerEmail = dto.CustomerEmail,
            CustomerAddress = dto.CustomerAddress,
            Items = dto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                VariantId = i.VariantId,
                Quantity = i.Quantity
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<bool> UpdateAsync(int id, CreateOrderDto dto)
    {
        var order = await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) return false;

        order.CustomerName = dto.CustomerName;
        order.CustomerEmail = dto.CustomerEmail;
        order.CustomerAddress = dto.CustomerAddress;

        _context.OrderItems.RemoveRange(order.Items);
        order.Items = dto.Items.Select(i => new OrderItem
        {
            ProductId = i.ProductId,
            VariantId = i.VariantId,
            Quantity = i.Quantity
        }).ToList();

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) return false;

        _context.OrderItems.RemoveRange(order.Items);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}