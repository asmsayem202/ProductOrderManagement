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

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _context.Products
            .Include(p => p.Variants)
            .OrderByDescending(p => p.Id)
            .ToListAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Brand = p.Brand,
            Type = p.Type,
            Variants = p.Variants.Select(v => new VariantDto
            {
                Id = v.Id,
                Color = v.Color,
                Specification = v.Specification,
                Size = v.Size
            }).ToList()
        });
    }



    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            Type = product.Type,
            Variants = product.Variants.Select(v => new VariantDto
            {
                Id = v.Id,
                Color = v.Color,
                Specification = v.Specification,
                Size = v.Size
            }).ToList()
        };
    }


    public async Task<Product> CreateAsync(CreateProductDto dto)
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

    public async Task<bool> UpdateAsync(int id, CreateProductDto dto)
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