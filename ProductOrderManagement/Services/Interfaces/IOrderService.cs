using ProductOrderManagement.Dtos;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> CreateAsync(CreateOrderDto dto);
    Task<bool> UpdateAsync(int id, CreateOrderDto dto);
    Task<bool> DeleteAsync(int id);
}