using FluentValidation;
using ProductOrderManagement.Dtos;

namespace ProductOrderManagement.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Brand).NotEmpty();
        RuleFor(p => p.Type).IsInEnum();
        RuleForEach(p => p.Variants).SetValidator(new VariantDtoValidator());
    }
}

public class VariantDtoValidator : AbstractValidator<VariantDto>
{
    public VariantDtoValidator()
    {
        RuleFor(v => v.Color).NotEmpty();
        RuleFor(v => v.Specification).NotEmpty();
        RuleFor(v => v.Size).IsInEnum();
    }
}