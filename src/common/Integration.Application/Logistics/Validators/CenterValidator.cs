using FluentValidation;
using Integration.Application.Logistics.Dto;

namespace Integration.Application.Logistics.Validators;

public class CenterValidator : AbstractValidator<CenterDto>
{
    public CenterValidator()
    {
        RuleFor(m => m.CenterCode)
            .NotEmpty()
            .Length(4);

        RuleFor(m => m.LegalName)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(m => m.Address)
            .NotEmpty();
    }
}