using RadiShop.Catalog.Application.Queries.Categories.GetAll;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.GetAll;

public sealed record GetAllCategoriesRequest(
    int PageNumber,
    int PageSize)
{
    public GetAllCategoriesQueryRequest ToQuery()
    {
        return new GetAllCategoriesQueryRequest(PageNumber, PageSize);
    }
}