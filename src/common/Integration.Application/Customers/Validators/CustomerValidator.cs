using FluentValidation;
using Integration.Application.Customers.Dto;

namespace Integration.Application.Customers.Validators;

public class CustomerValidator : AbstractValidator<CustomerDto>
{
    public CustomerValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
            .MinimumLength(3);
        
        RuleFor(m => m.Code)
            .NotEmpty()
            .MinimumLength(6);
        
        RuleFor(m => m.Document)
            .NotEmpty()
            .MinimumLength(9);
    }
}