using ProductOrderManagement.Dtos;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductDto dto);
    Task<bool> UpdateAsync(int id, ProductDto dto);
    Task<bool> DeleteAsync(int id);
}