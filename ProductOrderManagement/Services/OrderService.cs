using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.Data;
using ProductOrderManagement.Dtos;
using ProductOrderManagement.Enums;
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

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.Items)
                .ThenInclude(i => i.Product)
            .Include(o => o.Items)
                .ThenInclude(i => i.Variant)
                .OrderByDescending(o => o.Id)
            .ToListAsync();

        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            CustomerName = o.CustomerName,
            CustomerEmail = o.CustomerEmail,
            CustomerAddress = o.CustomerAddress,
            OrderDate = o.OrderDate,
            Items = o.Items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                ProductName = i.Product?.Name ?? "N/A",
                VariantColor = i.Variant?.Color ?? "N/A",
                VariantSpecification = i.Variant?.Specification ?? "N/A",
                VariantSize = i.Variant?.Size ?? Size.Small,
                Quantity = i.Quantity
            }).ToList()
        });
    }


    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.Items)
                .ThenInclude(i => i.Product)
            .Include(o => o.Items)
                .ThenInclude(i => i.Variant)
                .OrderByDescending(o => o.Id)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return null;

        return new OrderDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            CustomerEmail = order.CustomerEmail,
            CustomerAddress = order.CustomerAddress,
            OrderDate = order.OrderDate,
            Items = order.Items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                ProductName = i.Product?.Name ?? "N/A",
                VariantColor = i.Variant?.Color ?? "N/A",
                VariantSpecification = i.Variant?.Specification ?? "N/A",
                VariantSize = i.Variant?.Size ?? Size.Small,
                Quantity = i.Quantity
            }).ToList()
        };
    }


    public async Task<OrderDto> CreateAsync(CreateOrderDto createOrderDto)
    {
        var order = new Order
        {
            CustomerName = createOrderDto.CustomerName,
            CustomerEmail = createOrderDto.CustomerEmail,
            CustomerAddress = createOrderDto.CustomerAddress,
            Items = createOrderDto.Items.Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                VariantId = item.VariantId,
                Quantity = item.Quantity
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        var orderDto = await GetByIdAsync(order.Id);
        if (orderDto == null)
        {
            throw new Exception($"Order with ID {order.Id} was not found after creation.");
        }

        return orderDto;
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