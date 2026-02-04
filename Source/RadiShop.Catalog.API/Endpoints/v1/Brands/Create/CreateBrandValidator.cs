using FastEndpoints;
using FluentValidation;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Create;

public class CreateBrandValidator: Validator<CreateBrandRequest>
{
    public CreateBrandValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty().WithMessage(ValidationMessages.NotEmptyMessage)
            .MaximumLength(50).WithMessage(string.Format(ValidationMessages.MaximumLengthMessage, 50));
        
    }
}