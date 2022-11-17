using FluentValidation;
using Integration.Application.Catalog.Dto;

namespace Integration.Application.Catalog.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(m => m.Sku)
            .NotEmpty()
            .MinimumLength(3);
        
        RuleFor(m => m.Name)
            .NotEmpty()
            .MinimumLength(3);
        
        RuleFor(m => m.Description)
            .NotEmpty();

        RuleFor(m => m.CategoryId)
            .NotEmpty();
    }
}