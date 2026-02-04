using RadiShop.Catalog.Application.Queries.Categories.GetAll;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.GetAll;

public sealed record GetAllCategoriesResponse(Guid Id,
    string Title,
    string? Path)
{
    public static GetAllCategoriesResponse FromQuery(GetAllCategoriesQueryResponse query)
    {
        return new GetAllCategoriesResponse(
            query.Id,
            query.Title,
            query.Path);
    }
}