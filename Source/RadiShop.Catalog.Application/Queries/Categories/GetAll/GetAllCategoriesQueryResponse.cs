using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Application.Queries.Categories.GetAll;

public sealed record GetAllCategoriesQueryResponse(
    Guid Id,
    string Title,
    string? Path)
{
    public static GetAllCategoriesQueryResponse FromEntity(Category category)
    {
        return new GetAllCategoriesQueryResponse(
            category.Id,
            category.Title,
            category.Path); 
    }
}