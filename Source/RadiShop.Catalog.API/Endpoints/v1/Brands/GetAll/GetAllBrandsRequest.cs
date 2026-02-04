using RadiShop.Catalog.Application.Queries.Brands.GetAll;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.GetAll;

public sealed record GetAllBrandsRequest(
    int PageNumber,
    int PageSize)
{
    public GetAllBrandsQueryRequest ToQuery()
    {
        return new GetAllBrandsQueryRequest(PageNumber, PageSize);
    }
}