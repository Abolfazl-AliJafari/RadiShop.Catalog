using RadiShop.Catalog.Application.Queries.Brands.GetAll;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.GetAll;

public sealed record GetAllBrandsResponse(Guid Id,
    string Title)
{
    public static GetAllBrandsResponse FromQuery(GetAllBrandsQueryResponse query)
    {
        return new GetAllBrandsResponse(
            query.Id,
            query.Title);
    }
}