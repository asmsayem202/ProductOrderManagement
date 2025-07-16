using ProductOrderManagement.Dtos;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task<Product> CreateAsync(CreateProductDto dto);
    Task<bool> UpdateAsync(int id, CreateProductDto dto);
    Task<bool> DeleteAsync(int id);
}