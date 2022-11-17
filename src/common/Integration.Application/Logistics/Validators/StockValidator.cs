using FluentValidation;
using Integration.Application.Logistics.Dto;

namespace Integration.Application.Logistics.Validators;

public class StockValidator : AbstractValidator<StockDto>
{
    public StockValidator()
    {
        RuleFor(m => m.Sku)
            .NotEmpty();

        RuleFor(m => m.CenterCode)
            .NotEmpty();

        RuleFor(m => m.Quantity)
            .GreaterThanOrEqualTo(0);
    }
}