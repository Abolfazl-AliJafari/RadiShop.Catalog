using RadiShop.Catalog.Application.Queries.Brands.GetById;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.GetById;

public sealed record GetBrandByIdResponse(Guid Id,
    string Title)
{
    public static GetBrandByIdResponse FromQuery(GetBrandByIdQueryResponse query)
    {
        return new GetBrandByIdResponse(
            query.Id,
            query.Title);
    }
}