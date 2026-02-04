using FastEndpoints;
using FluentValidation;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Remove;

public class RemoveBrandValidator: Validator<RemoveBrandRequest>
{
    public RemoveBrandValidator()
    {
        RuleFor(o => o.Id)
            .NotEmpty().WithMessage(ValidationMessages.NotEmptyMessage);
    }
}