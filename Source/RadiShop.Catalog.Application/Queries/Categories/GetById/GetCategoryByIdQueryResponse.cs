using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Application.Queries.Categories.GetById;

public sealed record GetCategoryByIdQueryResponse(
    Guid Id,
    string Title,
    string? Path)
{
    public static GetCategoryByIdQueryResponse FromEntity(Category category)
    {
        return new GetCategoryByIdQueryResponse(
            category.Id,
            category.Title,
            category.Path); 
    }
}