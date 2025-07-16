using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.Data;
using ProductOrderManagement.Dtos;
using ProductOrderManagement.Models;
using ProductOrderManagement.Services.Interfaces;

namespace ProductOrderManagement.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context.Products.Include(p => p.Variants).ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _context.Products.Include(p => p.Variants).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product> CreateAsync(ProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Brand = dto.Brand,
            Type = dto.Type,
            Variants = dto.Variants.Select(v => new Variant
            {
                Color = v.Color,
                Specification = v.Specification,
                Size = v.Size
            }).ToList()
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> UpdateAsync(int id, ProductDto dto)
    {
        var product = await _context.Products.Include(p => p.Variants).FirstOrDefaultAsync(p => p.Id == id);
        if (product == null) return false;

        product.Name = dto.Name;
        product.Brand = dto.Brand;
        product.Type = dto.Type;

        _context.Variants.RemoveRange(product.Variants);
        product.Variants = dto.Variants.Select(v => new Variant
        {
            Color = v.Color,
            Specification = v.Specification,
            Size = v.Size
        }).ToList();

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.Include(p => p.Variants).FirstOrDefaultAsync(p => p.Id == id);
        if (product == null) return false;

        _context.Variants.RemoveRange(product.Variants);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}