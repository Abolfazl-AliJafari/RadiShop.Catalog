using FastEndpoints;
using FluentValidation;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Create;

public class CreateCategoryValidator: Validator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty().WithMessage(ValidationMessages.NotEmptyMessage)
            .MaximumLength(50).WithMessage(string.Format(ValidationMessages.MaximumLengthMessage, 50));
    }
}