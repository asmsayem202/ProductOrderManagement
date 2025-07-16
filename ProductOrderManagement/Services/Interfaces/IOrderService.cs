using ProductOrderManagement.Dtos;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<OrderDto?> GetByIdAsync(int id);
    Task<OrderDto> CreateAsync(CreateOrderDto dto);
    Task<bool> UpdateAsync(int id, CreateOrderDto dto);
    Task<bool> DeleteAsync(int id);
}