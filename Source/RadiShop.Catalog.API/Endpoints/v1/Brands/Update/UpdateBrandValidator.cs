using FastEndpoints;
using FluentValidation;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Update;

public class UpdateBrandValidator: Validator<UpdateBrandRequest>
{
    public UpdateBrandValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty().WithMessage(ValidationMessages.NotEmptyMessage)
            .MaximumLength(50).WithMessage(string.Format(ValidationMessages.MaximumLengthMessage, 50));
        
        RuleFor(o => o.Id)
            .NotEmpty().WithMessage(ValidationMessages.NotEmptyMessage);
    }
}