
using RadiShop.Catalog.Application.Queries.Categories.GetById;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.GetById;

public sealed record GetCategoryByIdResponse(Guid Id,
    string Title,
    string? Path)
{
    public static GetCategoryByIdResponse FromQuery(GetCategoryByIdQueryResponse query)
    {
        return new GetCategoryByIdResponse(
            query.Id,
            query.Title,
            query.Path);
    }
}