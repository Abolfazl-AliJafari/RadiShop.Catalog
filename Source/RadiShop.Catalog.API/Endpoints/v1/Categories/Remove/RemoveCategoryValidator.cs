using FastEndpoints;
using FluentValidation;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Remove;

public class RemoveCategoryValidator: Validator<RemoveCategoryRequest>
{
    public RemoveCategoryValidator()
    {
        RuleFor(o => o.Id)
            .NotEmpty().WithMessage(ValidationMessages.NotEmptyMessage);
    }
}