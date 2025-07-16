using FluentValidation;
using ProductOrderManagement.Dtos;

namespace ProductOrderManagement.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(o => o.CustomerName).NotEmpty();
        RuleFor(o => o.CustomerEmail).EmailAddress();
        RuleFor(o => o.CustomerAddress).NotEmpty();
        RuleForEach(o => o.Items).SetValidator(new CreateOrderItemDtoValidator());
    }
}

public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemDtoValidator()
    {
        RuleFor(i => i.ProductId).GreaterThan(0);
        RuleFor(i => i.VariantId).GreaterThan(0);
        RuleFor(i => i.Quantity).GreaterThan(0);
    }
}